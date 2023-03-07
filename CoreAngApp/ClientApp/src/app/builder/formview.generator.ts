import { AfterViewInit, ChangeDetectorRef, Component,  ComponentRef, Input, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { filter, map, switchMap } from 'rxjs/operators';
import { from, Observable } from 'rxjs';
import { defaultObject, Field, FieldOption, GenForm, RootObject } from './models';
import { ActivatedRoute, Router } from '@angular/router';
import { FormComponent } from './form.component';
import { BaseComponent } from './base.component';
import { ConfigService } from './configure.service';
@Component({
  selector: 'wrdynamic-component',
  template: `<ng-template #genComponent></ng-template>`,
  //styleUrls: ['./your-component.component.css']
})
export class ViewRenderComponent implements OnInit, AfterViewInit {
  @ViewChild('genComponent', { read: ViewContainerRef }) genComponent!: ViewContainerRef;
  @Input() data: any;
  private formComponents: { [key: string]: ComponentRef<BaseComponent> } = {};

  constructor(private cdRef: ChangeDetectorRef, private route: ActivatedRoute, private configsrv:ConfigService) { }

  ngOnInit() {
    // Subscribe to router events to check for the 'reload' query parameter
  }

  ngAfterViewInit() {
    this.route.paramMap.subscribe(params => {
      const formName = params.get('formname')!;
      this.configsrv.getConfigData().subscribe(data => {
        const frm = data.forms.find(item => item.name === formName);
        if (frm) {
          let formComponent: ComponentRef<BaseComponent> | undefined = this.formComponents[formName];
          if (formComponent) {
            // If component exists, update its configuration and data
            formComponent.instance.configuration = frm;
            formComponent.instance.formData = this.data;
          } else {
            // If component doesn't exist, create a new one and add it to the formComponents dictionary
            formComponent = this.genComponent.createComponent(FormComponent);
            formComponent.instance.configuration = frm;
            formComponent.instance.formName = frm.name;
            formComponent.instance.formData = this.data;
            this.formComponents[formName] = formComponent;
          }
          // Hide all other components except for the current one
          for (const [key, component] of Object.entries(this.formComponents)) {
            if (key !== formName) {
              component.location.nativeElement.style.display = 'none';
            }
          }
          // Show the current component
          formComponent.location.nativeElement.style.display = 'block';
        } else {
          // If form is not found, remove the component from the formComponents dictionary and hide it
          let formComponent: ComponentRef<BaseComponent> | undefined = this.formComponents[formName];
          if (formComponent) {
            formComponent.location.nativeElement.style.display = 'none';
            delete this.formComponents[formName];
          }
        }
        this.cdRef.detectChanges();
      });
    });
  }
}
