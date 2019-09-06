import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { EducationProgramApi } from '../apis/education-program.api';
import { environment } from '../../../environments/environment';
import { ProgramModel } from '../../shared/models/Program.model';
import { PagingModel } from 'src/app/shared/models/Paging.model';

@Injectable({
  providedIn: 'root'
})
export class EducationProgramService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getPrograms(): Observable<ProgramModel[]> {
    return this.httpClient.get<ProgramModel[]>(`${environment.coreApi}/${EducationProgramApi.getProgramsApi()}`);
  }

  public getPagingPrograms(currentPage: number): Observable<PagingModel<ProgramModel>> {
    return this.httpClient.get<PagingModel<ProgramModel>>(`${environment.coreApi}/${EducationProgramApi.getPagingProgramsApi(currentPage)}`);
  }

  public getProgram(id: string): Observable<ProgramModel> {
    return this.httpClient.get<ProgramModel>(`${environment.coreApi}/${EducationProgramApi.getProgramApi(id)}`);
  }

  public createProgram(program: ProgramModel): Observable<void> {
    return this.httpClient.post<void>(`${environment.coreApi}/${EducationProgramApi.getProgramsApi()}`, program);
  }

  public updateProgram(program: ProgramModel): Observable<void> {
    return this.httpClient.put<void>(`${environment.coreApi}/${EducationProgramApi.getProgramsApi()}`, program);
  }

  public changeActiveProgram(id: string): Observable<void> {
    return this.httpClient.post<void>(`${environment.coreApi}/${EducationProgramApi.changeActiveProgramApi(id)}`, null);
  }

  public deleteProgram(id: string): Observable<void> {
    return this.httpClient.delete<void>(`${environment.coreApi}/${EducationProgramApi.getProgramApi(id)}`);
  }
}
