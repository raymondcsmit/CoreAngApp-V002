import { Component, Input, OnInit } from '@angular/core';
import { GridOptions } from 'ag-grid-community';
import { ConfigService } from '../builder/configure.service';
import {  cfApplication } from './configure.model';

@Component({
  selector: 'app-configure-app',
  templateUrl: './configure-app.component.html',
  styleUrls: ['./configure-app.component.css']
})
export class ConfigureAppComponent implements OnInit {

  constructor(private configsrv:ConfigService) { }

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
