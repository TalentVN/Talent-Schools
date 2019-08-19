import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user.model';
import { environment } from 'src/environments/environment';
import { UserApi } from '../apis/user.api';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${environment.coreApi}/${UserApi.getUsersApi()}`);
  }

  public getUser(id: string): Observable<User> {
    return this.httpClient.get<User>(`${environment.coreApi}/${UserApi.getUserApi(id)}`);
  }

  public createUser(user: User): Observable<any> {
    return this.httpClient.post<any>(`${environment.coreApi}/${UserApi.getUsersApi()}`, user);
  }

  public updateUser(user: User): Observable<any> {
    return this.httpClient.put<any>(`${environment.coreApi}/${UserApi.getUsersApi()}`, user);
  }

  public deleteUser(id: string): Observable<any> {
    return this.httpClient.delete<any>(`${environment.coreApi}/${UserApi.getUserApi(id)}`);
  }
}
