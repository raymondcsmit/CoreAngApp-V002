import { Component, Input, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import {  Observable } from "rxjs";
import { BaseComponent } from "./base.component";

@Component({
  selector: "app-form",
  template: `
    <form [formGroup]="form" (ngSubmit)="saveAction()">
      <div *ngIf="loading$ | async">Loading...</div>
      <div *ngIf="error$ | async">Error: {{ error$ | async }}</div>
      <h3>{{ configuration.title }}</h3>
      <div *ngFor="let field of configuration.fields">
        <label [for]="field.name">{{ field.label }}</label>
        <div [ngSwitch]="field.type">
          <input
            *ngSwitchCase="'text'"
            [type]="field.type"
            [formControlName]="field.name"
          />
          <textarea
            *ngSwitchCase="'textarea'"
            [formControlName]="field.name"
          ></textarea>
          <select *ngSwitchCase="'select'" [formControlName]="field.name">
            <option *ngFor="let option of field.options" [value]="option.value">
              {{ option.label }}
            </option>
          </select>
        </div>
        <div
          *ngIf="
            form.get(field.name)?.invalid &&
            (form.get(field.name)?.dirty || form.get(field.name)?.touched)
          "
        >
          <div *ngIf="(form.get(field.name)?.errors)!['required']">
            {{ field.label }} is required.
          </div>
        </div>
      </div>
      <button type="submit">Save</button>
    </form>
  `,
})
export class FormComponent extends BaseComponent implements OnInit {
  constructor(
    fb: FormBuilder
  ) {
    super(fb);
  }
  @Input() key: string = this.configuration?.name;
  loading$?: Observable<boolean>;
  error$?: Observable<any>;

  saveAction() {
    this.actionPerformed.emit();
  }
  ngOnInit() {
    this.form = this.createForm(this.configuration);
  }
  createForm(data: any) {
    const controls: { [key: string]: FormControl } = {};
    if (this.configuration?.fields) {
      for (const field of this.configuration.fields) {
        controls[field.name] = new FormControl("", this.getValidators(field));
      }
      const formGroup = new FormGroup(controls);
      if (data) {
        formGroup.patchValue(data);
      }
      return formGroup;
    }
    return this.form;
  }

  getValidators(field: any) {
    const validators = [];
    if (field.required) {
      validators.push(Validators.required);
    }
    return validators;
  }
}
