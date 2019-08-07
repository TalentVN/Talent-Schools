import { Component, OnInit } from '@angular/core';
import { Router, CanActivate, ActivatedRoute, RouterStateSnapshot } from '@angular/router';
import { SchoolService } from '../../../core/services/school.service';
import { LocationService } from '../../../core/services/location.service';
import { EducationProgramService } from '../../../core/services/education-program.service';

import { SchoolModel } from '../../../shared/models/School.model';
import { ProgramModel } from '../../../shared/models/Program.model';
import { SchoolTypeOption } from '../../../shared/options/school-type.option';
import { SpecialtyOption } from '../../../shared/options/specialty.option';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  schools: SchoolModel[];
  maxScore: number;
  minScore: number;

  public cities: any[];
  public programs: ProgramModel[];

  public selectedSchoolType: any;
  public selectedSpecialty: any;
  public selectedProgram: any;
  public selectedCity: any;
  public tution: number;

  public schoolTypeOption: Array<{ value: number, text: string }>;
  public specialtyOption: Array<{ value: number, text: string }>;

  constructor(
    public schoolService: SchoolService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private locationService: LocationService,
    private educationProgramService: EducationProgramService
  ) {
    this.activatedRoute.queryParams.subscribe(p => console.log(p));
  }

  ngOnInit() {
    this.tution = 0;
    this.maxScore = 30;
    this.minScore = 0;

    this.schoolTypeOption = SchoolTypeOption;
    this.selectedSchoolType = SchoolTypeOption[0].value;

    this.specialtyOption = SpecialtyOption;
    this.selectedSpecialty = SpecialtyOption[0].value;

    // Init
    this.loadCities();
    this.loadPrograms();

    this.searchSchool();

  }

  searchSchool(): void {
    this.schoolService.getSchools().subscribe(
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
        this.selectedCity = null;
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
        this.selectedProgram = this.programs[1].id;
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
