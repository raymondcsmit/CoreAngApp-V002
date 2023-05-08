import { Injectable } from '@angular/core';
import { Observable, from } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import { cfApplication, cfForm, cfFormField, cfOption,  } from '../configure-app/configure.model';
import { RootObject, GenForm, Field, FieldOption, Application } from './models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  constructor(private http: HttpClient) { }

  getConfig(): Observable<Application[]> {
    const API_URL = 'https://localhost:44381/api/ConfigurationApp/Application/GetAll';
  
    return this.http.get(API_URL).pipe(
      map((response: any) => {
        const applications = response.data.$values.map((app: any) => {
          const forms = app.forms.$values.map((form: any) => {
            const fields = form.fields.$values.map((field: any) => {
              const options = field.options.$values.map((option: any) => ({
                label: option.label,
                value: option.value
              }));
              return {
                name: field.name,
                type: field.type,
                toolTip:field.toolTip,
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
            applicationId: app.applicationId,
            name: app.name,
            forms: forms
          };
        });
        return applications;
      })
    );
  }
  
}
