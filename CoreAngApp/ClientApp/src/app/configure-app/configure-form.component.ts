import { Component, Input, OnInit, ViewChild } from "@angular/core";
import {
  FormBuilder,
  FormGroup,
  Validators,
} from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { MatDialog } from "@angular/material/dialog";
import {
  ConfirmationDialogComponent,
  FormDialogComponent,
} from "./dialog.component";
import { cfApplication, cfFormField } from "./configure.model";
import { ConfigService } from "../builder/configure.service";

@Component({
  selector: "app-grid2",
  template: `
    <h1>{{ config?.name }}</h1>
    <table mat-table [dataSource]="dataSource" class="mat-elevation-z8">
      <ng-container
        *ngFor="let column of displayedColumns"
        [matColumnDef]="column"
      >
        <th mat-header-cell *matHeaderCellDef>{{ getFieldLabel(column) }}</th>
        <td mat-cell *matCellDef="let form">
          {{ getField(form.fields, column)?.value }}         
        </td>
      </ng-container>
      <ng-container matColumnDef="actions">
        <th mat-header-cell *matHeaderCellDef>Actions</th>
        <td mat-cell *matCellDef="let form">
          <button
            mat-icon-button
            color="primary"
            (click)="editFormDialog(form)"
          >
            <mat-icon>edit</mat-icon>
          </button>
          <button mat-icon-button color="warn" (click)="deleteForm(form)">
            <mat-icon>delete</mat-icon>
          </button>
        </td>
      </ng-container>
      <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
      <tr mat-row *matRowDef="let form; columns: displayedColumns"></tr>
    </table>
    <mat-paginator [pageSizeOptions]="[5, 10, 25, 100]"></mat-paginator>
    <button mat-button color="primary" (click)="addFormDialog()">
      Add Form
    </button>
  `,
})
export class ConfigureFormComponent implements OnInit {
    dataSource!: MatTableDataSource<any>;
    displayedColumns?: string[];
    @ViewChild(MatPaginator) paginator?: MatPaginator;
    @ViewChild(MatSort) sort?: MatSort;
    @Input() columnsToDisplay?: string[];
    config?: cfApplication;
    constructor(
      private fb: FormBuilder,
      private dialog: MatDialog,
      private configsrv: ConfigService
    ) {}
  
    ngOnInit() {
      this.displayedColumns =
        this.columnsToDisplay || this.config?.forms[0].displayedColumns;
      this.dataSource = new MatTableDataSource<any>([]);
      if (this.paginator) {
        this.dataSource.paginator = this.paginator;
      }
      if (this.sort) {
        this.dataSource.sort = this.sort;
      }
      this.configsrv.getConfigData2().subscribe((res: cfApplication) => {
        this.config = res;
      });
    }

  onSubmit(formValue: any) {
    const data = this.dataSource.data;
    data.push(formValue);
    this.dataSource.data = data;
  }

  getField(fields: cfFormField[], name: string): cfFormField | undefined {
    if (fields) {
      return fields.find((field) => field.name === name);
    }
    return undefined;
  }

  getFieldLabel(name: string): string {
    const field = this.config
      ? this.getField(this.config.forms[0].fields, name)
      : null;
    return field ? field.label : "";
  }
  openFormDialog(formData?: FormData, formIndex?: number): void {
    let form: FormGroup;
    let title: string;
    let action: string;
    const formConfig = this.config ? this.config.forms[formIndex || 0] : null;
    if (formConfig) {
      if (formData) {
        title = `Edit ${formConfig.title}`;
        action = "Save";
        const values = formData.get(formConfig.name); //[formConfig.name];
        form = this.fb.group({});
        formConfig.fields.forEach((field) => {
          form.addControl(
            field.name,
            this.fb.control(
              values![field.name as keyof typeof values],
              {
                validators: field.required ? Validators.required : null,
                updateOn: 'blur',
              }
            )
          );          
        });


        
      } else {
        title = `Add ${formConfig.title}`;
        action = "Add";
        form = this.fb.group({});
        formConfig.fields.forEach((field) => {
          form.addControl(
            field.name,
            this.fb.control("", field.required ? Validators.required : null)
          );
        });
      }

      const dialogRef = this.dialog.open(FormDialogComponent, {
        width: "400px",
        data: { title, form, action },
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          const data = this.dataSource.data;
          if (formData) {
            // Edit existing form data
            const index = data.findIndex((d) => d === formData);
            if (index >= 0) {
              data.splice(index, 1, result);
              this.dataSource.data = data;
            }
          } else {
            // Add new form data
            result.createdAt = new Date();
            data.push(result);
            this.dataSource.data = data;
          }
        }
      });
    }
  }
  addFormDialog(): void {
    const formData: any = {};
    if (this.config) {
      this.config.forms[0].fields.forEach((field) => {
        formData[field.name] = "";
      });
      const dialogRef = this.dialog.open(FormDialogComponent, {
        width: "600px",
        data: {
          title: "Add Form",
          form: this.fb.group(formData),
          fields: this.config.forms[0].fields,
        },
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          //console.log(result);
          const data = this.dataSource.data;
          //console.log(data);
          data.push(result);
          this.dataSource.data = data;
          //console.log(this.dataSource.data);
        }
      });
    }
  }

  editFormDialog(form: any) {
    const dialogRef = this.dialog.open(FormDialogComponent, {
      width: "600px",
      data: { title: "Edit Form", form },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        const data = this.dataSource.data;
        const index = data.findIndex((f) => f.id === form.id);
        data[index] = result;
      }
    });
  }

  deleteForm(form: any) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: "400px",
      data: {
        title: "Delete Form",
        message: "Are you sure you want to delete this form?",
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        const data = this.dataSource.data;
        const index = data.findIndex((f) => f.id === form.id);
        data.splice(index, 1);
      }
    });
  }
}
