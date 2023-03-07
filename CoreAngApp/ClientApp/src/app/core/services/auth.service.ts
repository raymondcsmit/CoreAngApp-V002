import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { HttpApi } from '../http/http-api';

const OAUTH_DATA = environment.oauth;
const BASE_URL=environment.apiUrl;
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  //private readonly baseUrl =`${BASE_URL}/auth/security` ;
  private readonly baseUrl =`auth/security` ;
  constructor(private http: HttpClient) {}
  login(username: string, password: string): Observable<any> {
    const loginData = { email: username, password: password };
   
    return this.http.post(`${this.baseUrl}/login`, loginData);
  }
  register(userRequest: any): Observable<any> {
    const data = {
      code: userRequest.codigo,
      email: userRequest.email,
      password: userRequest.password
    };

    return this.http.post(HttpApi.userRegister, data)
      .pipe(
        map((response: any) => {
          return response;
        })
      );
  }
  loginWithUserCredentials(username: string, password: string): Observable<any> {
    // Create a mock response object
    const mockResponse = {
      access_token: 'mock_access_token',
      token_type: 'Bearer',
      expires_in: 3600
    };
  
    // Simulate a delay to emulate network latency
    const delayTime = 1000;
  
    // Return an Observable that emits the mock response after a delay
    return new Observable(observer => {
      setTimeout(() => {
        localStorage.setItem('session', JSON.stringify(mockResponse));
        observer.next(mockResponse);
        observer.complete();
      }, delayTime);
    });
  }
  

  loginWithUserCredentials1(username: string, password: string): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/x-www-form-urlencoded');

    const body = new URLSearchParams();
    body.set('grant_type', 'password');
    body.set('client_id', OAUTH_DATA.client_id);
    body.set('client_secret', OAUTH_DATA.client_secret);
    body.set('username', username);
    body.set('password', password);
    body.set('scope', OAUTH_DATA.scope);

    return this.http.post(HttpApi.oauthLogin, body.toString(), { headers })
      .pipe(
        map((response: any) => {
          localStorage.setItem('session', JSON.stringify(response));
          return response;
        })
      );
  }

  loginWithRefreshToken(): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/x-www-form-urlencoded');

    const body = new URLSearchParams();
    body.set('grant_type', 'refresh_token');
    body.set('client_id', OAUTH_DATA.client_id);
    body.set('client_secret', OAUTH_DATA.client_secret);
    body.set('refresh_token', this.refreshToken);
    body.set('scope', OAUTH_DATA.scope);

    return this.http.post(HttpApi.oauthLogin, body.toString(), { headers })
      .pipe(
        map((response: any) => {
          localStorage.setItem('session', JSON.stringify(response));
          return response;
        })
      );
  }

  isLogged(): boolean {
    return localStorage.getItem('session') ? true : false;
  }

  logout(): void {
    localStorage.clear();
  }

  get accessToken() {
    return localStorage['session'] ? JSON.parse(localStorage['session']).access_token : null;
  }

  get refreshToken() {
    return localStorage['session'] ? JSON.parse(localStorage['session']).refresh_token : null;
  }
}
