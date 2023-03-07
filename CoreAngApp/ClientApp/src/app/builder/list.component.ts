import { Component, Input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseComponent } from './base.component';
import { select, Store } from '@ngrx/store';
import { GenericState,loadGenericData,
  createGenericData,
  updateGenericData,
  deleteGenericData,
  selectGenericData,
  selectGenericLoading,
  selectGenericError } from '../ngrxstore/generic.store';
import { Field } from './models';

@Component({
  selector: 'comp-list',
  template: `
    <div class="carded">
    <div class="top-bg accent"></div>
    <div class="center">
        <div class="header accent">
            <h2>Customers</h2>

            <div>
                <button type="button" mat-raised-button class="u-margin-l-8">
                    <mat-icon>delete</mat-icon>DELETE
                </button>
                
                <button type="button" mat-raised-button class="u-margin-l-8">
                    <mat-icon>edit</mat-icon>EDIT
                </button>

                <button type="button" mat-raised-button class="u-margin-l-8">
                    <mat-icon>add</mat-icon>ADD
                </button>
            </div>
        </div>

        <div class="content-card">
            <perfect-scrollbar>
            <mat-table [dataSource]="dataSource">
              <ng-container *ngFor="let column of configuration?.fields" [matColumnDef]="column.name">
                <mat-header-cell *matHeaderCellDef>{{ column.label }}</mat-header-cell>
                <mat-cell *matCellDef="let element">{{element[column.name]}}</mat-cell>
                <!-- <mat-cell *matCellDef="let element">{{ getCellValue(element, column) }}</mat-cell> -->

                <!-- <mat-cell *matCellDef="let element">{{ column.cellExp(element) }}</mat-cell> -->
              </ng-container>
              <mat-header-row *matHeaderRowDef="configuration.displayedColumns"></mat-header-row>
              <mat-row *matRowDef="let row; columns: configuration.displayedColumns;"></mat-row>
            </mat-table>
            </perfect-scrollbar>

            <mat-paginator [pageSizeOptions]="[5, 10, 20]" showFirstLastButtons></mat-paginator>
        </div>
    </div>
</div>
  `,
})
  export class ListComponent extends BaseComponent implements OnInit {
    constructor(fb: FormBuilder, private http: HttpClient,private store: Store<GenericState<any>>) {
      super(fb);
    }
    @Input() key: string=this.configuration?.name;   
  
    loading$?: Observable<boolean>;
    error$?: Observable<any>;   
 
  ngOnInit() {
    this.store.dispatch(loadGenericData({ key: this.key }));

    this.loading$ = this.store.pipe(select(selectGenericLoading(this.key)));
    this.error$ = this.store.pipe(select(selectGenericError(this.key)));
    this.store.pipe(select(selectGenericData<any>(this.key))).subscribe((data) => {
      this.dataSource=data;
    });
  }
  getCellValue(element: any, column: Field): any {    
      return element[column.name];
    }
  
  onSubmit() {
    const data = this.form.value;
    if (data.id) {
      this.store.dispatch(updateGenericData({ key: this.key,id: data['id'], payload: data }));
    } else {
      this.store.dispatch(createGenericData({ key: this.key, payload: data }));
    }
  }

  onDelete(idx: string) {
    this.store.dispatch(deleteGenericData({ key: this.key, id: idx, payload: { idx } }));
  }
}
