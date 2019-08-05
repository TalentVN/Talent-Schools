import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router, CanActivate, ActivatedRoute, RouterStateSnapshot } from '@angular/router';

import { SchoolService } from '../../../core/services/school.service';
import { RatingService } from '../../../core/services/rating.service';

import { SchoolModel } from '../../../shared/models/School.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  private schoolId: string;
  public filter: number;

  public schoolModel: SchoolModel;

  ratingCtrl = new FormControl(null, Validators.required);

  constructor(
    private schoolService: SchoolService,
    private router: ActivatedRoute,
    private ratingService: RatingService
  ) {
    this.subscribeRouter();
    this.subcribeQueryParams();
  }

  ngOnInit() {
  }

  private subscribeRouter() {
    this.router.paramMap.subscribe(params => {
      this.schoolId = params.get('id');
      if (this.schoolId) {
        this.loadSchoolProfile(this.schoolId);
      }
    });
  }

  private subcribeQueryParams() {
    this.router.queryParamMap.subscribe(params => {
      this.filter = + params.get('filter');

      this.loadSchoolRatings(this.schoolId, this.filter);
    });
  }

  private loadSchoolProfile(schoolId: string) {
    this.schoolService.getSchool(schoolId).subscribe(
      data => {
        this.schoolModel = data;
        // Load depend
        this.loadSchoolPrograms(schoolId);
        this.loadSchoolMajors(schoolId);
      },
      error => {
        console.log(error);
      }
    );
  }

  private loadSchoolPrograms(schoolId: string) {
    this.schoolService.getSchoolPrograms(schoolId).subscribe(
      data => {
        this.schoolModel.programs = data;
      },
      error => {
        console.log(error);
      }
    );
  }

  private loadSchoolMajors(schoolId: string) {
    this.schoolService.getSchoolMajors(schoolId).subscribe(
      data => {
        this.schoolModel.majors = data;
      },
      error => {
        console.log(error);
      }
    );
  }

  private loadSchoolRatings(schoolId: string, ratingType: number) {
    this.ratingService.queryRatings(schoolId, ratingType).subscribe(
      data => {
        this.schoolModel.ratings = data;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }

  public onRated(value: boolean): void {
    this.loadSchoolRatings(this.schoolId, this.filter);
  }
}
