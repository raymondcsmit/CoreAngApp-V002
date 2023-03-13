import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { NestedTreeControl } from '@angular/cdk/tree';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfigService } from '../builder/configure.service';
import { cfApplication, cfForm, cfFormField } from './configure.model';
import { BehaviorSubject } from 'rxjs';

interface FormNode {
  name: string;
  type: string;
  children?: FormNode[];
}

@Component({
  selector: 'app-form-tree',
  template: `<mat-tree [dataSource]="dataSource" [treeControl]="treeControl">
  <!-- This is the tree node template for application -->
  <mat-tree-node *matTreeNodeDef="let application" matTreeNodePadding>
    <button mat-icon-button disabled></button>
    <span>{{ application.Application }}</span>
  </mat-tree-node>

  <!-- This is the tree node template for forms -->
  <mat-tree-node *matTreeNodeDef="let formNode; when: hasChild" matTreeNodePadding>
    <button mat-icon-button matTreeNodeToggle
            [attr.aria-label]="'toggle ' + formNode.title">
      <mat-icon>{{ treeControl.isExpanded(formNode) ? 'expand_more' : 'chevron_right' }}</mat-icon>
    </button>
    <span>{{ formNode.title }}</span>
  </mat-tree-node>

  <!-- This is the leaf node template for form fields -->
  <mat-tree-node *matTreeNodeDef="let fieldNode" matTreeNodePadding>
    <button mat-icon-button disabled></button>
    <span>{{ fieldNode.label }}</span>
  </mat-tree-node>
</mat-tree>

`
})
export class FormTreeComponent implements OnInit {

  treeControl = new NestedTreeControl<FormNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<FormNode>();
  forms?: cfForm[];
  formGroup?: FormGroup;
  selectedIndex: number = -1;

  constructor(private fb: FormBuilder,private configsrv: ConfigService) { }

  ngOnInit(): void {
    // Initialize data
    this.configsrv.getConfigData2().subscribe((res:cfApplication) => {
      this.forms = res.forms;
      this.dataSource.data = this.getTreeData();
    });
  }

  getTreeData(): FormNode[] {
    const treeData: FormNode[] = [
      {
        name: 'Application',
        type: 'Application',
        children: this.forms ? this.forms.map(f => {
          return {
            name: f.title,
            type: f.type,
            children: f.fields.map(this.createFieldNode)
          }
        }) : []
      }
    ];
    return treeData;
  }

  createFieldNode(field: cfFormField): FormNode {
    return {
      name: field.label,
      type: field.type,
      children: field.type === 'select' ? field?.options?.map(o => {
        return {
          name: o.label,
          type: 'option',
          children: []
        }
      }) : []
    }
  }

  hasChild = (_: number, node: FormNode) => !!node.children && node.children.length > 0;

  // Method to change the selected form
  setForm(index: number) {
    if(this.forms){
      this.selectedIndex = index;
      this.formGroup = this.createFormGroup(this.forms[index].fields);
    }
  }

  // Method to create form group with dynamic form fields
  createFormGroup(fields: any[]) {
    const formGroupControls: Record<string, any> = {};
    for (const field of fields) {
      const control = this.fb.control(field.value || '', field.required ? Validators.required : null);
      formGroupControls[field.name] = control;
    }
    return this.fb.group(formGroupControls);
  }

  // Method to submit form data
  onSubmit() {
    if (this.formGroup?.valid && this.forms && this.selectedIndex >= 0) {
      const formData = this.formGroup.getRawValue();
      this.forms[this.selectedIndex].fields.forEach(f => {
        f.value = formData[f.name];
      });
      this.formGroup.reset();
    }
  }

  // Method to edit existing form data
  editData(index: number) {
    if(this.forms){
      this.setForm(index);
    }
  }

  // Method to delete existing form data
  deleteData(index:number){
    if(this.forms){
      this.forms.splice(index, 1);
      this.dataSource.data = this.getTreeData();
    }}
  }