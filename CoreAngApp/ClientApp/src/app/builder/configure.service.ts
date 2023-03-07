import { Injectable } from '@angular/core';
import { Observable, from } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import { RootObject, GenForm, Field, FieldOption } from './models';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  constructor() {}

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
            name: formData.name,
            fields: fields
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
}
