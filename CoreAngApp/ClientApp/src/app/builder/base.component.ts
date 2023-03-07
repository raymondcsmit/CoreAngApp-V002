import { Component } from '@angular/core';
import { Form, FormBuilder, FormGroup } from '@angular/forms';
import { defaultObject, GenForm } from './models';

@Component({
  selector: 'app-base',
  template: '<p>Base Component</p>'
})
export class BaseComponent  {
    public configuration: GenForm=defaultObject.forms[0];
    public formData: any;
    public form: FormGroup;
    public dataSource: any;
    public formName:string="defaultname";
    public unique_key: number=0;
    public parentRef: any;
    constructor(private fb: FormBuilder) {
      this.form = this.fb.group({});
    }
  // Define properties and methods for the base component
}