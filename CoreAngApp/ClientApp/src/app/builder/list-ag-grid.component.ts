import { Component, Input, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ColDef , GridOptions } from "ag-grid-community";
import {  delay, Observable, of } from "rxjs";
import { BaseComponent } from "./base.component";

@Component({
  selector: "app-ag-grid",
  template: `
  <h3>{{formName}}</h3>
  <ag-grid-angular
  style="width: 100%; height: 200px;"
  class="ag-theme-alpine"
  [columnDefs]="columnDefs"
  [rowData]="rowData$ | async"
></ag-grid-angular>
  `,
})
export class ListAgGridComponent extends BaseComponent implements OnInit {

  constructor(
    fb: FormBuilder
  ) {
    super(fb);
  }
  @Input() key: string = this.configuration?.name;
  rowData$: Observable<any[]> = this.loadData();
   rowData:any[]= [
    {field1: 'ewe1', field2: '1ewew', field3: '2'},
    {field1: 'ewe2', field2: '2ewew', field3: '2'},
    {field1: 'ewe3', field2: '3ewew', field3: '2'}
  ];
columnDefs: ColDef[] = [
  { headerName: 'Field 1', field: 'field1', minWidth: 100 },
  { headerName: 'Field 2', field: 'field2', minWidth: 100 },
  { headerName: 'Field 3', field: 'field3', minWidth: 100 },
];
  
  public gridOptions: GridOptions = {
  pagination: true,
  rowHeight: 50,
  enableRangeSelection: true,
  statusBar:  {
    statusPanels: [
      { statusPanel: 'statusBarComponent', align: 'center' },
      { statusPanel: 'agTotalRowCountComponent', align: 'left', key: 'statusBarCompKeyRowCount' }, // Total row count,
      { statusPanel: 'agFilteredRowCountComponent' }, // Count after filtering
      { statusPanel: 'agSelectedRowCountComponent' }, // Selected row count
      {
        statusPanel: 'agAggregationComponent', // Summary information Average, Count, Min, Max and Sum
        key: 'statusBarCompKey',
        statusPanelParams: {
          aggFuncs: ['sum', 'count', 'min', 'max', 'avg']
        }
      }
    ]
  },
  
   defaultColDef: {
    enableValue: true,
    sortable:true,
    enableRowGroup: true,
    enablePivot: true,
    // editable: true
  }
}

  listData1?: Observable<any[]>;
  vrtdata?:any[];
  
  loadData(): Observable<any[]> {
    const students: any[] = [
      {field1: 'ewe1', field2: '1ewew', field3: '2'},
      {field1: 'ewe2', field2: '2ewew', field3: '2'},
      {field1: 'ewe3', field2: '3ewew', field3: '2'}
    ];
    return of(students).pipe(delay(500));
  }

  saveAction() {
    this.actionPerformed.emit();
  }
  ngOnInit() {
    
    this.listData1=this.loadData();
    this.listData1.subscribe((data:any[])=>{
    console.log('Column Definition',this.columnDefs);
    this.vrtdata = data;
        this.gridOptions.rowData=data; 
        this.gridOptions.columnDefs =this.columnDefs
      console.log('row data is : ',data);
    })
  }
  

  getValidators(field: any) {
    const validators = [];
    if (field.required) {
      validators.push(Validators.required);
    }
    return validators;
  }
}
