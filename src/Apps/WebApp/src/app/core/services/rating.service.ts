import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { RatingApi } from '../../core/apis/rating.api';
import { RatingModel } from '../../shared/models/Rating.model';

@Injectable({
  providedIn: 'root'
})
export class RatingService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getRatings(schoolId: string): Observable<RatingModel[]> {
    return this.httpClient.get<RatingModel[]>(`${environment.coreApi}/${RatingApi.getRatingApi(schoolId)}`);
  }
}
