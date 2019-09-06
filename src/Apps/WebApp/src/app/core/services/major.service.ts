import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { MajorApi } from '../apis/major.api';
import { environment } from '../../../environments/environment';
import { MajorModel } from '../../shared/models/major.model';
import { PagingModel } from 'src/app/shared/models/Paging.model';

@Injectable({
  providedIn: 'root'
})
export class MajorService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getMajors(): Observable<MajorModel[]> {
    return this.httpClient.get<MajorModel[]>(`${environment.coreApi}/${MajorApi.getMajorsApi()}`);
  }

  public getPagingMajors(currentPage: number): Observable<PagingModel<MajorModel>> {
    return this.httpClient.get<PagingModel<MajorModel>>(`${environment.coreApi}/${MajorApi.getPagingMajorsApi(currentPage)}`);
  }

  public getMajor(id: string): Observable<MajorModel> {
    return this.httpClient.get<MajorModel>(`${environment.coreApi}/${MajorApi.getMajorApi(id)}`);
  }

  public createMajor(program: MajorModel): Observable<void> {
    return this.httpClient.post<void>(`${environment.coreApi}/${MajorApi.getMajorsApi()}`, program);
  }

  public updateMajor(program: MajorModel): Observable<void> {
    return this.httpClient.put<void>(`${environment.coreApi}/${MajorApi.getMajorsApi()}`, program);
  }

  public changeActiveMajor(id: string): Observable<void> {
    return this.httpClient.post<void>(`${environment.coreApi}/${MajorApi.changeActiveMajorApi(id)}`, null);
  }

  public deleteMajor(id: string): Observable<void> {
    return this.httpClient.delete<void>(`${environment.coreApi}/${MajorApi.getMajorApi(id)}`);
  }
}
