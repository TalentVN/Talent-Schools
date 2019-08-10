import { Component, OnInit } from '@angular/core';
import { Router, CanActivate, ActivatedRoute, RouterStateSnapshot } from '@angular/router';
import { SchoolService } from '../../../core/services/school.service';
import { LocationService } from '../../../core/services/location.service';
import { EducationProgramService } from '../../../core/services/education-program.service';

import { SchoolModel } from '../../../shared/models/School.model';
import { ProgramModel } from '../../../shared/models/Program.model';
import { SchoolTypeOption } from '../../../shared/options/school-type.option';
import { SpecialtyOption } from '../../../shared/options/specialty.option';
import { SearchModel } from '../../../shared/models/Searching.model';
import { CityModel } from 'src/app/shared/models/City.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public schools: SchoolModel[];
  public cities: CityModel[];
  public programs: ProgramModel[];

  public searchModel = new SearchModel();

  public schoolTypeOption: Array<{ value: number, text: string }>;
  public specialtyOption: Array<{ value: number, text: string }>;

  constructor(
    public schoolService: SchoolService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private locationService: LocationService,
    private educationProgramService: EducationProgramService
  ) {
    this.activatedRoute.queryParams.subscribe(
      p => {
        this.searchModel.ratingType = +p.filter;
      }
    );
  }

  ngOnInit() {
    this.searchModel.tution = 0;
    this.searchModel.maxScore = 30;
    this.searchModel.minScore = 0;

    this.schoolTypeOption = SchoolTypeOption;
    this.searchModel.selectedSchoolType = SchoolTypeOption[0].value;

    this.specialtyOption = SpecialtyOption;
    this.searchModel.selectedSpecialty = SpecialtyOption[0].value;

    // Init
    this.loadCities();
    this.loadPrograms();

    this.searchSchool();

  }

  searchSchool(): void {
    console.log(this.searchModel);
    this.schoolService.searchSchools(this.searchModel).subscribe(
      data => {
        this.schools = data;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }

  directSchoolProfie(schoolId: string) {
    this.router.navigate([`/schools/${schoolId}`], { queryParams: { filter: 0 } });
  }

  public schoolTypeChange(item: any): void {
    console.log(item);
  }

  private loadCities(): void {
    this.locationService.getCities().subscribe(
      data => {
        this.cities = data;
      },
      error => {
        console.log(error);
      }
    );
  }

  private loadPrograms(): void {
    this.educationProgramService.getPorgrams().subscribe(
      data => {
        this.programs = data;
        this.searchModel.selectedProgram = this.programs[1].id;
      },
      error => {
        console.log(error);
      }
    );
  }

  public modelChanged() {
    this.searchSchool();
  }

}
