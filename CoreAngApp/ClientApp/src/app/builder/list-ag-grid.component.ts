import { Component, Input, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ColDef, CsvExportParams, ExcelExportParams, GridApi, GridOptions, GridReadyEvent } from "ag-grid-community";
import { delay, Observable, of } from "rxjs";
import { BaseComponent } from "./base.component";

@Component({
  selector: "app-ag-grid",
  template: `
    <div class="container">
    <div>
      <button
        (click)="onBtExport()"
        style="margin-bottom: 5px; font-weight: bold;"
      >
        Export to Excel
      </button>
    </div>
    
    <ag-grid-angular
      style="width: 100%; height: 200px;"
      class="ag-theme-alpine"
      [defaultColDef]="defaultColDef"
      [gridOptions]="gridOptions"
      [columnDefs]="columnDefs"
      [rowData]="listData$ | async"
      (gridReady)="onGridReady($event)"
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
  gridOptions: any;
  columnDefs: any[] = [];
  private gridApi!: GridApi<any>;
  
  // gridOptions: GridOptions = {
  //   enableExcelExport: true,
  // };
  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    resizable: true,
    minWidth: 100,
    flex: 1,
  };
  saveAction() {
    this.actionPerformed.emit();
  }

  onBtExport() {
    const params: CsvExportParams={
    fileName: `${this.formName}exportedfile`
    }
    this.gridApi.exportDataAsCsv(params);
    // const params: ExcelExportParams = {
    //   fileName: 'exported_data.xlsx',
    // };
    // this.gridApi.exportDataAsExcel(params);
  }
  
  onGridReady(params: GridReadyEvent<any>) {
    this.gridApi = params.api;
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
    this.gridOptions = {
      enableExcelExport: true,
    };
  }

  getValidators(field: any) {
    const validators = [];
    if (field.required) {
      validators.push(Validators.required);
    }
    return validators;
  }
}
