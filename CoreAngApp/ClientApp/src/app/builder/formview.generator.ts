import { AfterViewInit, ChangeDetectorRef, Component,  ComponentRef, Input, NgZone, OnDestroy, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { delay, filter, map, switchMap, takeUntil } from 'rxjs/operators';
import { from, Observable, of, Subject, Subscription } from 'rxjs';
import { defaultObject, Field, FieldOption, GenForm, RootObject } from './models';
import { ActivatedRoute, Router } from '@angular/router';
import { FormComponent } from './form.component';
import { BaseComponent } from './base.component';
import { ConfigService } from './configure.service';
import { Select, Store } from '@ngxs/store';
import { AddData, GenericStateModel, GenericStateSelectors, LoadData } from '../generic-ngxs';
import { ListAgGridComponent } from './list-ag-grid.component';
@Component({
  selector: 'wrdynamic-component',
  template: `<ng-template #genComponent></ng-template>`
})
export class ViewRenderComponent implements OnInit, AfterViewInit,OnDestroy {
  @ViewChild('genComponent', { read: ViewContainerRef }) genComponent!: ViewContainerRef;
  data: any;
  stateData$!: Observable<any>;
  private formComponents: { [key: string]: ComponentRef<BaseComponent> } = {};
  myStateSubscription?: Subscription;
  myStateSubscription1?: Subscription;

  loading$?: Observable<boolean>;
  error$?: Observable<any>;
  listData$?: Observable<any[]>;
  listData?:any[];
  constructor(private store: Store,private cdRef: ChangeDetectorRef,private ngZone: NgZone, private route: ActivatedRoute, private configsrv:ConfigService) { }

  ngOnInit() {}
  ngOnDestroy(): void {
    this.myStateSubscription?.unsubscribe();
    this.myStateSubscription1?.unsubscribe();
    //this.formComponents?.destroy();
  }
  loadData(): Observable<any[]> {
    const students: any[] = [
      {field1: "ewe1", field2 : "1ewew",field3:""},
      {field1: "ewe2", field2 : "2ewew",field3:""},
      {field1: "ewe3", field2 : "3ewew",field3:""}
    ];
    return of(students).pipe(delay(500));
  }
  ngAfterViewInit() {
    this.route.paramMap.subscribe(params => {
       
      const formName = params.get('formname')!;
      
      this.bindDataToStore(formName);
      this.generateForm(formName);    

      this.store.dispatch(new LoadData<any[]>(this.loadData(), formName)); 
      this.ngZone.runOutsideAngular(() => {
        this.cdRef.detectChanges();
      });
    });
  }
  generateForm(formName: string) {
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
          //formComponent = this.genComponent.createComponent(FormComponent);
          switch(frm.type)
          {
            case 'Form': formComponent = this.genComponent.createComponent(FormComponent); break;
            case 'List': formComponent = this.genComponent.createComponent(ListAgGridComponent); break;
            default: break;
          }
          //formComponent = this.genComponent.createComponent(ListAgGridComponent);
          //ListAgGridComponent
          formComponent.instance.configuration = frm;
          formComponent.instance.formName = frm.name;
          //formComponent.instance.formData = this.data;
          formComponent.instance.listData$ = this.listData$;
          this.formComponents[formName] = formComponent;
          // Listen to child component action
          formComponent.instance.actionPerformed.subscribe(() => {
            const vdata = this.formComponents[formName].instance.form.value;
            this.store.dispatch(new AddData<any>(vdata, formName));
            //console.log('Action performed in child component');
          });
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
      
    });
  }
  bindDataToStore(formName: string) {
    this.loading$ = this.store.select(GenericStateSelectors.getLoading(formName));
      this.error$ = this.store.select(GenericStateSelectors.getError(formName));
      this.listData$ = this.store.select(GenericStateSelectors.getListData(formName));  

      this.myStateSubscription = this.listData$.subscribe((d: any[]) => {
        this.listData=d;
        console.log('this is myStateSubscription',d);
      });
  }
}
