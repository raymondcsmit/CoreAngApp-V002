import { NgModule } from '@angular/core';
import { CompBuilderModule } from '../builder/compBuilder.module';

import { SharedModule } from '../shared/shared.module';
import { DashboarRoutingModule } from './dashboard-routing.module';
import { DashboardLayoutModule } from './layouts/layouts.module';

@NgModule({
  imports: [
    SharedModule,
    DashboardLayoutModule,
    DashboarRoutingModule,
    CompBuilderModule
  ],
  declarations: [
    ...DashboarRoutingModule.components
  ]
})
export class DashboardModule { }
