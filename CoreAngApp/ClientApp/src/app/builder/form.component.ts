import { Component, Input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseComponent } from './base.component';
import { select, Store } from '@ngrx/store';
import { GenericState,loadGenericData,
  createGenericData,
  updateGenericData,
  deleteGenericData,
  selectGenericData,
  selectGenericLoading,
  selectGenericError } from '../ngrxstore/generic.store';

@Component({
  selector: 'app-form',
  template: `
    <form [formGroup]="form" (ngSubmit)="onSubmit()">
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
          <div *ngIf="form.get(field.name)?.errors!['required']">
            {{ field.label }} is required.
          </div>
        </div>
      </div>
    </form>
  `,
})
  export class FormComponent extends BaseComponent implements OnInit {
    constructor(fb: FormBuilder, private http: HttpClient,private store: Store<GenericState<any>>) {
      super(fb);
    }
    @Input() key: string=this.configuration?.name;   
  
    loading$?: Observable<boolean>;
    error$?: Observable<any>;   
 
  ngOnInit() {
    this.store.dispatch(loadGenericData({ key: this.key }));

    this.loading$ = this.store.pipe(select(selectGenericLoading(this.key)));
    this.error$ = this.store.pipe(select(selectGenericError(this.key)));

    this.store.pipe(select(selectGenericData<any>(this.key))).subscribe((data) => {
      this.form = this.createForm(data[0]);
    });
  }
  createForm(data: any) {
    const controls: { [key: string]: FormControl } = {}; // Using an object instead of an array

    if (this.configuration?.fields) {
      for (const field of this.configuration.fields) {
        controls[field.name] = new FormControl('', this.getValidators(field));
      }
      const formGroup = new FormGroup(controls);
      if (data) {
        formGroup.patchValue(data);
      }
      return formGroup;
    }
    return this.form;
  }

  onSubmit() {
    const data = this.form.value;
    if (data.id) {
      this.store.dispatch(updateGenericData({ key: this.key,id: data['id'], payload: data }));
    } else {
      this.store.dispatch(createGenericData({ key: this.key, payload: data }));
    }
  }

  onDelete(idx: string) {
    this.store.dispatch(deleteGenericData({ key: this.key, id: idx, payload: { idx } }));
  }
  getValidators(field: any) {
    const validators = [];
    if (field.required) {
      validators.push(Validators.required);
    }
    return validators;
  }
}
