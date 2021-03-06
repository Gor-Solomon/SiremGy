import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserModel } from '../models/userModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
    baseUrl = environment.apiUrl;

    constructor(private httpClient: HttpClient) { }

    getUsers(): Observable<UserModel[]> {
      return this.httpClient.get<UserModel[]>(this.baseUrl + 'users');
    }

    getUser(id: number): Observable<UserModel> {
      return this.httpClient.get<UserModel>(this.baseUrl + 'users/' + id);
    }

}
