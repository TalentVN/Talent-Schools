import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { EducationProgramApi } from '../apis/education-program.api';
import { environment } from '../../../environments/environment';
import { ProgramModel } from '../../shared/models/Program.model';

@Injectable({
  providedIn: 'root'
})
export class EducationProgramService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getPorgrams(): Observable<ProgramModel[]> {
    return this.httpClient.get<ProgramModel[]>(`${environment.coreApi}/${EducationProgramApi.getProgramsApi()}`);
  }
}
