import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigureAppComponent } from './configure-app.component';
import { AgGridModule } from 'ag-grid-angular';
import { ConfigureAppRoutingModule } from './configure-app.routing.module';

@NgModule({
  imports: [
    CommonModule, AgGridModule,ConfigureAppRoutingModule
  ],
  declarations: [
    ...ConfigureAppRoutingModule.components
  ]
})
export class ConfigureAppModule { }
