import { Component, OnInit } from '@angular/core';
import { Router, CanActivate, ActivatedRoute, RouterStateSnapshot } from '@angular/router';
import { SchoolService } from '../../../core/services/school.service';

import { SchoolModel } from '../../../shared/models/School.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  sliderValue: number;
  schools: SchoolModel[];
  maxScore: number;
  minScore: number;

  constructor(
    public schoolService: SchoolService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.activatedRoute.queryParams.subscribe(p => console.log(p));
  }

  ngOnInit() {
    this.sliderValue = 50000;
    this.maxScore = 30;
    this.minScore = 0;

    this.searchSchool();
  }

  searchSchool(): void {
    this.schoolService.getSchools().subscribe(
      data => {
        this.schools = data;
      },
      error => {
        console.log(error);
      }
    );
  }

  directSchoolProfie(schoolId: string) {
    this.router.navigate([`/schools/${schoolId}`]);
  }

}
