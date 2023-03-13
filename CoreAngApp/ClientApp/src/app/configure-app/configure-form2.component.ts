import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfigService } from '../builder/configure.service';
import { cfApplication, cfForm } from './configure.model';


@Component({
  selector: 'app-grid3',
  template: `<div *ngIf="formGroup">
  <form [formGroup]="formGroup" (ngSubmit)="onSubmit()">
    <mat-table [dataSource]="dataSource" matSort>

      <ng-container *ngFor="let col of displayedColumns; let i = index" [matColumnDef]="col">
        <mat-header-cell *matHeaderCellDef mat-sort-header>{{ col | titlecase }}</mat-header-cell>
        <mat-cell *matCellDef="let element">{{ element[col] }}</mat-cell>
      </ng-container>

      <mat-header-row *matHeaderRowDef="displayedColumns"></mat-header-row>
      <mat-row *matRowDef="let row; columns: displayedColumns;"></mat-row>

    </mat-table>

    <div fxLayout="row" fxLayoutAlign="space-between center">
      <button type="submit" mat-raised-button color="primary">{{ selectedIndex === -1 ? 'Add' : 'Update' }}</button>
      <button type="button" mat-raised-button color="warn" *ngIf="selectedIndex !== -1" (click)="setForm(-1)">Cancel</button>
    </div>
  </form>
</div>
`
})
export class ConfigureGrid3Component implements OnInit {

    application?: cfApplication;
    forms?: cfForm[];
    displayedColumns?: string[];
    dataSource: any[] = [];
    formGroup?: FormGroup;
    selectedIndex: number = -1;
  
    constructor(private fb: FormBuilder,private configsrv: ConfigService) { }
  
    ngOnInit(): void {
      // Initialize data
      this.configsrv.getConfigData2().subscribe((res:cfApplication) => {
          this.application = res;
          console.log(this.application);
        });
      // Set default form
      this.forms = this.application?.forms;
      this.setForm(0);
    }
  
    // Method to change the selected form
    setForm(index: number) {
      if(this.forms){
        this.selectedIndex = index;
        this.displayedColumns = this.forms[index].displayedColumns;
        this.dataSource = [];
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
      if (this.formGroup?.valid && this.dataSource) {
        const formData = this.formGroup.getRawValue();
        this.dataSource.push(formData);
        this.formGroup.reset();
      }
    }
  
    // Method to edit existing form data
    editData(index: number) {
      if(this.dataSource){
        this.dataSource[index] = this.formGroup?.getRawValue();
        this.formGroup?.reset();
        this.selectedIndex = -1;
      }
    }
  
    // Method to delete existing form data
    deleteData(index:number){
      if(this.dataSource){
        this.dataSource.splice(index, 1);
      }
    }
  }