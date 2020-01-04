import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { RegisterModel } from '../models/RegisterModel';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = environment.apiUrl + 'auth/';
  private jwtHelper = new JwtHelperService();
  private userInfo = null;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((Response: any) => {
        const user = Response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.refreshTokenInfo();
        }
      })
    );
  }

  Register(model: RegisterModel) {
    console.log(2);
    return this.http.post(this.baseUrl + 'RegisterUser', model).pipe(
      map((Response: any) => {
        const result = Response;
        console.log(result);
        if (result.succeed) {
          const user = JSON.stringify(result.value);
          localStorage.setItem('user', user);
        }
      }
      ));
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    this.userInfo = null;
    localStorage.removeItem('token');
  }

  refreshTokenInfo() {
    const token = localStorage.getItem('token');
    this.userInfo = this.jwtHelper.decodeToken(token);
  }

  getUserInfo(): any {
    return this.userInfo;
  }
}
