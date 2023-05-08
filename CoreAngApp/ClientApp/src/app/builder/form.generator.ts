import { Component, ComponentFactoryResolver, ComponentRef, Input, OnInit, ViewContainerRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, switchMap } from 'rxjs/operators';

import { from, Observable } from 'rxjs';
import { Application, defaultObject, Field, FieldOption, GenForm, RootObject } from './models';
import { ActivatedRoute, Router } from '@angular/router';
import { FormComponent } from './form.component';
import { BaseComponent } from './base.component';
import { ConfigService } from './configure.service';

@Component({
  selector: 'app-wr-render-component',
  template: `
  <h2>App Renderer</h2>
  `,
  //styleUrls: ['./your-component.component.css']
})
export class WRRenderComponent implements OnInit {

  rootObject: Application = defaultObject;
  @Input() component: any;
  @Input() data: any;
  constructor(private http: HttpClient,public viewContainerRef: ViewContainerRef,private configsrv:ConfigService,  private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.configsrv.getConfig().subscribe(data => {
      this.rootObject = data[0];
        this.rootObject.forms.$values.forEach((frm:GenForm)=>{
            const componentRef: ComponentRef<BaseComponent> = this.viewContainerRef.createComponent(FormComponent);
            componentRef.instance.formData = this.data;
            componentRef.instance.configuration=frm;
            const url = this.activatedRoute.snapshot.url.join('/'+frm.name);
            const route = {
              path: url,
              component: this.component
            };
            this.router.config.push(route);
        });

    });
    // this.configsrv.getConfigData().subscribe(data => {
    //   this.rootObject = data;
    //     this.rootObject.forms.forEach((frm:GenForm)=>{
    //         const componentRef: ComponentRef<BaseComponent> = this.viewContainerRef.createComponent(FormComponent);
    //         componentRef.instance.formData = this.data;
    //         componentRef.instance.configuration=frm;
    //         const url = this.activatedRoute.snapshot.url.join('/'+frm.name);
    //         const route = {
    //           path: url,
    //           component: this.component
    //         };
    //         this.router.config.push(route);
    //     });

    // });

    
  }
}
