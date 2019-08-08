import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LocationApi } from '../apis/location.api';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCities(): Observable<any[]> {
    return this.httpClient.get<any[]>(`${environment.coreApi}/${LocationApi.getCitiesApi()}`);
  }
}
