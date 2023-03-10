import { Component, Input, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ColDef, GridOptions } from "ag-grid-community";
import { delay, Observable, of } from "rxjs";
import { BaseComponent } from "./base.component";

@Component({
  selector: "app-ag-grid",
  template: `
    <h3>{{ formName }}</h3>
    <div class="parent-element">
    <ag-grid-angular
      style="width: 100%; height: 200px;"
      class="ag-theme-alpine"
      [columnDefs]="columnDefs"
      [rowData]="listData$ | async"
    ></ag-grid-angular>
</div>
  `,
styles: [`
.parent-element {
  height: calc(100vh - 150px);
  padding: 10px;
}
`]
})
export class ListAgGridComponent extends BaseComponent implements OnInit {
  constructor(fb: FormBuilder) {
    super(fb);
  }
  @Input() key: string = this.configuration?.name;

  columnDefs: any[] = [];

  saveAction() {
    this.actionPerformed.emit();
  }
  ngOnInit() {
    if (
      this.configuration &&
      this.configuration.displayedColumns &&
      this.configuration.fields
    ) {
      this.columnDefs = this.configuration.displayedColumns
        .map((column) => {
          const field = this.configuration.fields?.find(
            (fd) => fd.name === column
          );
          if (field) {
            return {
              headerName: field.label,
              field: field.name,
            };
          } else {
            return null;
          }
        })
        .filter((def) => def !== null);
    } else {
      this.columnDefs = [];
    }
  }

  getValidators(field: any) {
    const validators = [];
    if (field.required) {
      validators.push(Validators.required);
    }
    return validators;
  }
}
