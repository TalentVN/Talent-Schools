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

  public schoolModel: SchoolModel;

  ratingCtrl = new FormControl(null, Validators.required);

  constructor(
    private schoolService: SchoolService,
    private router: ActivatedRoute,
    private ratingService: RatingService
  ) {
    this.subscribeRouter();
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

  private loadSchoolProfile(schoolId: string) {
    this.schoolService.getSchool(schoolId).subscribe(
      data => {
        this.schoolModel = data;
        console.log(data);
        // Load depend
        this.loadSchoolPrograms(schoolId);
        this.loadSchoolMajors(schoolId);
        this.loadSchoolRatings(schoolId);
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
        console.log(data);
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
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }

  private loadSchoolRatings(schoolId: string) {
    this.ratingService.getRatings(schoolId).subscribe(
      data => {
        this.schoolModel.ratings = data;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
}
