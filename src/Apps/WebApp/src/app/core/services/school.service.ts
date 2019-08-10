import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { SchoolApi } from '../apis/school.api';
import { environment } from '../../../environments/environment';

import { SchoolModel } from '../../shared/models/School.model';
import { MajorModel } from '../../shared/models/Major.model';
import { ProgramModel } from 'src/app/shared/models/Program.model';
import { SearchModel } from '../../shared/models/Searching.model';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getSchools(): Observable<SchoolModel[]> {
    return this.httpClient.get<SchoolModel[]>(`${environment.coreApi}/${SchoolApi.getSchoolsApi()}`);
  }

  public getSchool(schoolId: string): Observable<SchoolModel> {
    return this.httpClient.get<SchoolModel>(`${environment.coreApi}/${SchoolApi.getSchoolApi(schoolId)}`);
  }

  public createSchool(school: SchoolModel): Observable<SchoolModel> {
    return this.httpClient.post<SchoolModel>(`${environment.coreApi}/${SchoolApi.getSchoolsApi()}`, school);
  }

  public searchSchools(searchModel: SearchModel): Observable<SchoolModel[]> {
    return this.httpClient.post<SchoolModel[]>(`${environment.coreApi}/${SchoolApi.searchSchoolsApi()}`, searchModel);
  }

  public getSchoolMajors(schoolId: string): Observable<MajorModel[]> {
    return this.httpClient.get<MajorModel[]>(`${environment.coreApi}/${SchoolApi.getSchoolMajorApi(schoolId)}`);
  }

  public getSchoolPrograms(schoolId: string): Observable<MajorModel[]> {
    return this.httpClient.get<ProgramModel[]>(`${environment.coreApi}/${SchoolApi.getSchoolProgarmApi(schoolId)}`);
  }

  public updateSchool(school: SchoolModel): Observable<SchoolModel> {
    return this.httpClient.put<SchoolModel>(`${environment.coreApi}/${SchoolApi.getSchoolsApi()}`, school);
  }

  public deleteSchool(schoolId: string): Observable<SchoolModel> {
    return this.httpClient.delete<SchoolModel>(`${environment.coreApi}/${SchoolApi.getSchoolApi(schoolId)}`);
  }
}

