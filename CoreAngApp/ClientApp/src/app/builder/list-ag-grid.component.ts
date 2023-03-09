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
    <ag-grid-angular #agGrid style="width: 100%; height: 200px;" class="ag-theme-alpine"
  [gridOptions]="gridOptions"
  [rowData]="listData1 | async"
  (cellValueChanged)="saveAction()"
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
 
//   columnDefs : ColDef[]= [
//     { field: 'field1' },
//     { field: 'field2' },
//     { field: 'field3' }
// ];
  
columnDefs : ColDef[]=[
    { headerName: 'Form Title', field: 'title', minWidth: 100 },
    { headerName: 'Form Name', field: 'name', minWidth: 100 },
    { headerName: 'Field 1', field: 'field1', minWidth: 100 },
    { headerName: 'Field 2', field: 'field2', minWidth: 100 },
    { headerName: 'Field 3', field: 'field3', minWidth: 100 }
  ];
  // public gridOptions: GridOptions = {
  //   //treeData: true,
  //   //groupDefaultExpanded: -1,
    
  //   pagination: true,
  //   rowSelection: 'single',
  //   animateRows: true,
  // };
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
      {field1: 'ewe1', field2: '1ewew', field3: ''},
      {field1: 'ewe2', field2: '2ewew', field3: ''},
      {field1: 'ewe3', field2: '3ewew', field3: ''}
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
       // this.gridOptions.api?.sizeColumnsToFit();
       
     //   this.gridOptions.api?.getEditingCells();
      //this.gridOptions.api?.setRowData(data);
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
