import { Component, Input, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { GridOptions } from "ag-grid-community";
import {  delay, Observable, of } from "rxjs";
import { cfApplication } from "../configure-app/configure.model";
import { BaseComponent } from "./base.component";
import { ConfigService } from "./configure.service";

@Component({
  selector: "app-ag-grid-dummy",
  template: `
    <ag-grid-angular
  style="width: 100%; height: 100%;"
  class="ag-theme-alpine"
  [rowData]="data.forms"
  [columnDefs]="columnDefs"
  [gridOptions]="gridOptions"
>
</ag-grid-angular>
  `,
})
export class ListAgGridComponentDummy  implements OnInit {

  constructor(
    fb: FormBuilder,private configsrv:ConfigService
  ) {
    
  }
  ngOnInit() {
    this.configsrv.getConfigData2().subscribe((res:cfApplication) => {
      this.data = res;
    });
  }
  data!: cfApplication;

  columnDefs = [
    { headerName: 'Form Title', field: 'title', minWidth: 200 },
    { headerName: 'Form Name', field: 'name', minWidth: 200 },
    { headerName: 'Field 1', field: 'field1', minWidth: 200 },
    { headerName: 'Field 2', field: 'field2', minWidth: 200 },
    { headerName: 'Field 3', field: 'field3', minWidth: 200 }
  ];
  public gridOptions: GridOptions = {
    treeData: true,
    groupDefaultExpanded: -1,
    animateRows: true,
  };
}
