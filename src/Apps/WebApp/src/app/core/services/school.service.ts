import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SchoolApi } from '../apis/school.api';
import { environment } from '../../../environments/environment';

import { SchoolModel } from '../../shared/models/School.model';
import { MajorModel } from '../../shared/models/Major.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getSchools(): Observable<SchoolModel[]> {
    return this.httpClient.get<SchoolModel[]>(`${environment.coreApi}/${SchoolApi.getSchoolsApi}`);
  }

  public getSchool(schoolId: string): Observable<SchoolModel> {
    return this.httpClient.get<SchoolModel>(`${environment.coreApi}/${SchoolApi.getSchoolApi(schoolId)}`);
  }

  public createSchool(school: SchoolModel): Observable<SchoolModel> {
    return this.httpClient.post<SchoolModel>(`${environment.coreApi}/${SchoolApi.getSchoolsApi}`, school);
  }

  public getSchoolMajors(schoolId: string): Observable<MajorModel[]> {
    return this.httpClient.get<MajorModel[]>(`${environment.coreApi}/${SchoolApi.getSchoolMajorApi(schoolId)}`);
  }

}

