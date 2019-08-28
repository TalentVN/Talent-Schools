import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { MajorApi } from '../apis/major.api';
import { environment } from '../../../environments/environment';
import { MajorModel } from '../../shared/models/major.model';

@Injectable({
  providedIn: 'root'
})
export class MajorService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getPorgrams(): Observable<MajorModel[]> {
    return this.httpClient.get<MajorModel[]>(`${environment.coreApi}/${MajorApi.getMajorsApi()}`);
  }
}
