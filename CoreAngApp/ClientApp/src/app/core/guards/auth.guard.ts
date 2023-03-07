import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { LoginState } from 'src/app/ngrxstore/auth.store';

import { AuthService } from '../services/auth.service';
@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private store: Store, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const loginState = this.store.selectSnapshot(LoginState);
    if (loginState.accessToken) {
      return true;
    } else {
      this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
  }
}
// @Injectable()
// export class AuthGuard implements CanActivate {

//   constructor(
//     private auth: AuthService,
//     private router: Router
//   ) { }

//   canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
//     if (this.auth.isLogged()) {
//       // logged in so return true
//       return true;
//     }

//     // not logged in so redirect to login page with the return url
//     this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
//     return false;
//   }
// }
