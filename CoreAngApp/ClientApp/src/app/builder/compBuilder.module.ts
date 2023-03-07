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
const routes: Routes = [
  { path: '', component: ViewRenderComponent }
];
@NgModule({
  imports: [
    CommonModule,CoreModule,SharedModule,ReactiveFormsModule, RouterModule.forChild(routes)
  ],
  declarations: [FormComponent,WRRenderComponent,ViewRenderComponent,ListComponent],
  exports: [
    WRRenderComponent,ViewRenderComponent
  ]
})
export class CompBuilderModule { }
