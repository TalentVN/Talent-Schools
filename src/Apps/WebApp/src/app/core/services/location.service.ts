import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LocationApi } from '../apis/location.api';
import { environment } from '../../../environments/environment';

import { CityModel } from 'src/app/shared/models/City.model';
import { CountryModel } from 'src/app/shared/models/Country.model';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCities(): Observable<CityModel[]> {
    return this.httpClient.get<CityModel[]>(`${environment.coreApi}/${LocationApi.getCitiesApi()}`);
  }

  public getCountries(): Observable<CountryModel[]> {
    return this.httpClient.get<CountryModel[]>(`${environment.coreApi}/${LocationApi.getCountriesApi()}`);
  }
}
