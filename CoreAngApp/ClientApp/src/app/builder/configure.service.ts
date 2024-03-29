import { Injectable } from '@angular/core';
import { Observable, from } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import { cfApplication, cfForm, cfFormField, cfOption,  } from '../configure-app/configure.model';
import { RootObject, GenForm, Field, FieldOption } from './models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  constructor(private http: HttpClient) { }

  getConfigData(): Observable<RootObject> {
    return from(fetch('./assets/formconfig.json')).pipe(
      switchMap(res => res.json()),
      map((data: RootObject) => {
        const forms: GenForm[] = [];

        data.forms.forEach((formData: GenForm) => {
          const fields: Field[] = [];

          formData?.fields?.forEach((fieldData: any) => {
            const options: FieldOption[] = fieldData?.options?.map((option: any) => ({
              label: option.label,
              value: option.value
            }));

            const field: Field = {
              name: fieldData.name,
              type: fieldData.type,
              label: fieldData.label,
              required: fieldData.required,
              options: options
            };

            fields.push(field);
          });

          const form: GenForm = {
            title: formData.title,
            type:formData.type,
            name: formData.name,
            fields: fields,
            displayedColumns: formData.displayedColumns
          };

          forms.push(form);
        });

        const rootObject: RootObject = {
          Application: data.Application,
          forms: forms
        };

        return rootObject;
      })
    );
  }

  getConfigData2(): Observable<cfApplication> {
    return from(fetch('./assets/formconfig.json')).pipe(
      switchMap(res => res.json()),
      map((data: cfApplication) => {
        const forms: cfForm[] = [];

        data.forms.forEach((formData: cfForm) => {
          const fields: cfFormField[] = [];

          formData?.fields?.forEach((fieldData: any) => {
            const options: cfOption[] = fieldData?.options?.map((option: any) => ({
              label: option.label,
              value: option.value
            }));

            const field: cfFormField = {
              name: fieldData.name,
              type: fieldData.type,
              label: fieldData.label,
              required: fieldData.required,
              options: options,
              value:undefined
            };

            fields.push(field);
          });

          const form: cfForm = {
            title: formData.title,
            name: formData.name,
            type:formData.type,
            fields: fields,
            displayedColumns: formData.displayedColumns
          };

          forms.push(form);
        });

        const rootObject: cfApplication = {
          name: data.name,
          forms: forms
        };

        return rootObject;
      })
    );
  }
  getConfig(): Observable<RootObject> {
    const API_URL = 'https://localhost:44381/api/ConfigurationApp/Application/GetAll';

    return this.http.get(API_URL).pipe(
      map((response: any) => {
        const forms = response.data.$values.map((form: any) => {
          const fields = form.fields.$values.map((field: any) => {
            const options = field.options.$values.map((option: any) => ({
              label: option.label,
              value: option.value
            }));
            return {
              name: field.name,
              type: field.type,
              label: field.label,
              required: field.required,
              options: options
            };
          });
          return {
            title: form.title,
            type: 'Form',
            name: form.name,
            displayedColumns: form.displayedColumns,
            fields: fields
          };
        });
        return {
          Application: response.data.$values[0].name,
          forms: forms
        };
      })
    );
  }
  
}
