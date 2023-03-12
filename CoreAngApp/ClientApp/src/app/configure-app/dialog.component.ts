import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-form-dialog',
  template: `
    <h2 mat-dialog-title>{{data.title}}</h2>
    <mat-dialog-content>
      <form [formGroup]="form" (ngSubmit)="onSubmit()">
        <ng-container *ngFor="let field of data.fields">
          <mat-form-field>
            <input matInput [formControlName]="field.name" [placeholder]="field.label">
          </mat-form-field>
        </ng-container>
      </form>
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button (click)="onNoClick()">Cancel</button>
      <button mat-button color="primary" [disabled]="form.invalid" (click)="onSubmit()">Save</button>
    </mat-dialog-actions>
  `,
})
export class FormDialogComponent {
  form: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<FormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder
  ) {
    this.form = data.form;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }
}

@Component({
  selector: 'app-confirmation-dialog',
  template: `
  <h2 mat-dialog-title>{{ data.title }}</h2>
  <mat-dialog-content>{{ data.message }}</mat-dialog-content>
  <mat-dialog-actions>
    <button mat-button color="primary" [mat-dialog-close]="true">Yes</button>
    <button mat-button [mat-dialog-close]="false">No</button>
  </mat-dialog-actions>
  `,
})
export class ConfirmationDialogComponent {
  // constructor(
  //   public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
  //   @Inject(MAT_DIALOG_DATA) public data: any
  // ) {}
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
  // onNoClick(): void {
  //   this.dialogRef.close();
  // }

  // onYesClick(): void {
  //   this.dialogRef.close(true);
  // }
}
