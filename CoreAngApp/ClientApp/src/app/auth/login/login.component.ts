import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';

import { AuthService } from '../../core/services/auth.service';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { Store } from '@ngxs/store';
import {LoginAction} from '../../ngrxstore/auth.store'
import { LoginResponse } from 'src/app/core/models/response.model';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  message!: string;
  loginSubscription!: Subscription;
  loginLoading = false;
  static path = () => ['login'];

  constructor(
    private authService: AuthService,
    public formBuilder: FormBuilder,
    private router: Router,
    public snackBar: MatSnackBar,
    private store: Store
  ) {
    this.initFormBuilder();
  }


 

  ngOnInit() {
  }

  loginUser() {
    this.loginLoading = true;
    this.authService.login(this.form.value.email, this.form.value.password).subscribe(
      (response: LoginResponse) => {
        
        this.store.dispatch(new LoginAction(response.data));
  this.loginLoading=false;
        // Navigate to dashboard on successful login
        // this.router.navigate(DashboardComponent.path());
        this.router.navigate(['/dashboard']);
      },
      (error: any) => {
        // Display error message on failed login
        this.snackBar.open('In correct', '', {
          duration: 3000,
          horizontalPosition: 'end',
          verticalPosition: 'bottom'
        });
      }
    );
  }

  private initFormBuilder() {
    this.form = this.formBuilder.group({
      email: ['waqar7@yahoo.com', [
        Validators.required,
        Validators.email
      ]],
      password: ['Admin@123', Validators.required]
    });
  }

}
