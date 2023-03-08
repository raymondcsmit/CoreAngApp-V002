import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigureAppComponent } from './configure-app.component';

export const ConfigureAppRoutes: Routes = [
    {
        path: '',
        component: ConfigureAppComponent
    }
];

@NgModule({
    imports: [ RouterModule.forChild(ConfigureAppRoutes) ],
    exports: [ RouterModule ]
})

export class ConfigureAppRoutingModule {
  static components = [ConfigureAppComponent];
}
