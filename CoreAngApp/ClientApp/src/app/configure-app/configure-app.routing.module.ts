import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigureAppComponent } from './configure-app.component';
import { ConfigureFormComponent } from './configure-form.component';
import { ConfigureGrid3Component } from './configure-form2.component';
import { FormTreeComponent } from './configure-tree.component';

export const ConfigureAppRoutes: Routes = [
    {
        path: '',
        component: ConfigureAppComponent,
        
    },{path:'configureform',component:FormTreeComponent}
];

@NgModule({
    imports: [ RouterModule.forChild(ConfigureAppRoutes) ],
    exports: [ RouterModule ]
})

export class ConfigureAppRoutingModule {
  static components = [ConfigureAppComponent,ConfigureFormComponent,ConfigureGrid3Component,FormTreeComponent];
}
