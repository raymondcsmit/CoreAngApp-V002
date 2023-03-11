import { Component, Input, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ColDef, ColumnApi, CsvExportParams, ExcelExportParams, GridApi, GridOptions, GridReadyEvent } from "ag-grid-community";
import { delay, Observable, of } from "rxjs";
import { BaseComponent } from "./base.component";
import printDoc from "./pdfBuilder/printDoc.js";

//import printDoc from "pdfBuilder/printDoc";

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
      <button (click)="exportAsPdf($event)" 
          matTooltip="Export to PDF"
          mat-raised-button>
          Export as PDF
            <mat-icon>get_app</mat-icon>
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
  private gridColumnApi!: ColumnApi;
  //#region Pdf settings
  PDF_HEADER_COLOR = "#f8f8f8";
  PDF_INNER_BORDER_COLOR = "#dde2eb";
  PDF_OUTER_BORDER_COLOR = "#babfc7";
  PDF_LOGO =
    "https://raw.githubusercontent.com/AhmedAGadir/ag-grid-todo-list-react-typescript/master/src/assets/new-ag-grid-logo.png";
  PDF_PAGE_ORITENTATION = "landscape";
  PDF_WITH_HEADER_IMAGE = true;
  PDF_WITH_FOOTER_PAGE_COUNT = true;
  PDF_HEADER_HEIGHT = 25;
  PDF_ROW_HEIGHT = 15;
  PDF_ODD_BKG_COLOR = "#fcfcfc";
  PDF_EVEN_BKG_COLOR = "#ffffff";
  PDF_WITH_CELL_FORMATTING = true;
  PDF_WITH_COLUMNS_AS_LINKS = true;
  PDF_SELECTED_ROWS_ONLY = false;
  exportAsPdf(event:any): void {
    event.preventDefault();
      const printParams = {
        PDF_HEADER_COLOR: this.PDF_HEADER_COLOR,
        PDF_INNER_BORDER_COLOR: this.PDF_INNER_BORDER_COLOR,
        PDF_OUTER_BORDER_COLOR: this.PDF_OUTER_BORDER_COLOR,
        PDF_LOGO: this.PDF_LOGO,
        PDF_PAGE_ORITENTATION: this.PDF_PAGE_ORITENTATION,
        PDF_WITH_HEADER_IMAGE: this.PDF_WITH_HEADER_IMAGE,
        PDF_WITH_FOOTER_PAGE_COUNT: this.PDF_WITH_FOOTER_PAGE_COUNT,
        PDF_HEADER_HEIGHT: this.PDF_HEADER_HEIGHT,
        PDF_ROW_HEIGHT: this.PDF_ROW_HEIGHT,
        PDF_ODD_BKG_COLOR: this.PDF_ODD_BKG_COLOR,
        PDF_EVEN_BKG_COLOR: this.PDF_EVEN_BKG_COLOR,
        PDF_WITH_CELL_FORMATTING: this.PDF_WITH_CELL_FORMATTING,
        PDF_WITH_COLUMNS_AS_LINKS: this.PDF_WITH_COLUMNS_AS_LINKS,
        PDF_SELECTED_ROWS_ONLY: this.PDF_SELECTED_ROWS_ONLY
      };
      printDoc(printParams, this.gridApi, this.gridColumnApi);
    }
  //#endregion Pdf settings
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
  }
  
  onGridReady(params: GridReadyEvent<any>) {
    this.gridColumnApi = params.columnApi;
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
