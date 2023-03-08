import { AfterViewInit, ChangeDetectorRef, Component,  ComponentRef, Input, OnDestroy, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { filter, map, switchMap, takeUntil } from 'rxjs/operators';
import { from, Observable, Subject } from 'rxjs';
import { defaultObject, Field, FieldOption, GenForm, RootObject } from './models';
import { ActivatedRoute, Router } from '@angular/router';
import { FormComponent } from './form.component';
import { BaseComponent } from './base.component';
import { ConfigService } from './configure.service';
import { Store } from '@ngxs/store';
@Component({
  selector: 'wrdynamic-component',
  template: `<ng-template #genComponent></ng-template>`,
  //styleUrls: ['./your-component.component.css']
})
export class ViewRenderComponent implements OnInit, AfterViewInit,OnDestroy {
  @ViewChild('genComponent', { read: ViewContainerRef }) genComponent!: ViewContainerRef;
  data: any;
  stateData$!: Observable<any>;
  private formComponents: { [key: string]: ComponentRef<BaseComponent> } = {};
  private unsubscribe$: Subject<void> = new Subject();
  private unsubscribeToState$: Subject<void> = new Subject();
  constructor(private store: Store,private cdRef: ChangeDetectorRef, private route: ActivatedRoute, private configsrv:ConfigService) { }

  ngOnInit() {}
  ngOnDestroy(): void {
    this.unsubscribeToState$.next();
    this.unsubscribeToState$.complete();
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  ngAfterViewInit() {
    this.route.paramMap.subscribe(params => {
      const formName = params.get('formname')!;
      this.store.select(state => state.myState.myValue)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(myValue => {
        this.stateData$ = this.store.select(state => state[formName]);
        //this.stateData$ = this.store.select(state => state[`$state.generic.{formName}`]);
        // Handle the state value change here.
      });
      this.stateData$.pipe(takeUntil(this.unsubscribeToState$)).subscribe(stateVal =>{
        this.data=stateVal.activeValue;
      });

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
