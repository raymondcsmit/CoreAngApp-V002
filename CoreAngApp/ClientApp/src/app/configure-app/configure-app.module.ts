import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigureAppComponent } from './configure-app.component';
import { AgGridModule } from 'ag-grid-angular';
import { ConfigureAppRoutingModule } from './configure-app.routing.module';
import { MaterialModule } from '../shared/material.module';
import { ConfirmationDialogComponent, FormDialogComponent } from './dialog.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule, AgGridModule,MaterialModule,ConfigureAppRoutingModule,ReactiveFormsModule
  ],
  declarations: [
    ...ConfigureAppRoutingModule.components, ConfirmationDialogComponent,FormDialogComponent
  ]
})
export class ConfigureAppModule { }
