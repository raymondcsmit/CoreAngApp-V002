import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { genericReducer } from './ngrxstore/generic.store';
import { NgxsModule } from '@ngxs/store';
import { LoginState } from './ngrxstore/auth.store';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GenericNgxsModule } from './generic-ngxs/generic-ngxs.module';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    //BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,HttpClientModule,
    CommonModule,
    StoreModule.forRoot({ generic: genericReducer }),
    NgxsModule.forRoot([LoginState]),
    AppRoutingModule, // Main routes for application
    CoreModule,       // Singleton objects (services, components and resources that are loaded only at app.module level)
    GenericNgxsModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
