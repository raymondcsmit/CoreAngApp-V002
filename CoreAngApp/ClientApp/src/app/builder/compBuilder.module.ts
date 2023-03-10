import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormComponent } from './form.component';
import { WRRenderComponent } from './form.generator';
import { ViewRenderComponent } from './formview.generator';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { ListComponent } from './list.component';
import { ListAgGridComponent } from './list-ag-grid.component';
import { AgGridModule } from 'ag-grid-angular';
import { ListAgGridComponentDummy } from './list-ag-grid.component copy';
import { CsvExportModule, ModuleRegistry } from 'ag-grid-community';
const routes: Routes = [
  { path: '', component: ViewRenderComponent },
  //{path:'aggrid',component:ListAgGridComponentDummy}
];
// Register the required feature modules with the Grid
ModuleRegistry.registerModules([
  //ClientSideRowModelModule,
  CsvExportModule,
  //ExcelExportModule,
  //MenuModule,
]);
@NgModule({
  imports: [
    
    CommonModule,CoreModule,SharedModule,AgGridModule, ReactiveFormsModule, RouterModule.forChild(routes)
  ],
  declarations: [FormComponent,WRRenderComponent,ViewRenderComponent,ListComponent, ListAgGridComponent,ListAgGridComponentDummy],
  exports: [
    WRRenderComponent,ViewRenderComponent
  ]
})
export class CompBuilderModule { }
