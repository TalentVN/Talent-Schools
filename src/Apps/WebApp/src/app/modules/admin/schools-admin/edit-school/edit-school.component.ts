import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { map, filter, switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { SchoolService } from 'src/app/core/services/school.service';
import { LocationService } from 'src/app/core/services/location.service';
import { EducationProgramService } from 'src/app/core/services/education-program.service';
import { MajorService } from 'src/app/core/services/major.service';

import { SchoolTypeOption } from 'src/app/shared/options/school-type.option';
import { CityModel } from 'src/app/shared/models/City.model';
import { CountryModel } from 'src/app/shared/models/Country.model';
import { ProgramModel } from 'src/app/shared/models/Program.model';
import { MajorModel } from 'src/app/shared/models/Major.model';

@Component({
  selector: 'app-edit-school',
  templateUrl: './edit-school.component.html',
  styleUrls: ['./edit-school.component.scss']
})
export class EditSchoolComponent implements OnInit {

  editForm: FormGroup;
  loading = false;
  submitted = false;

  schoolId: string;
  schoolTypes = SchoolTypeOption;
  countries$: Observable<CountryModel[]>;
  cities$: Observable<CityModel[]>;
  programs$: Observable<ProgramModel[]>;
  majors$: Observable<MajorModel[]>;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private schoolService: SchoolService,
    private locationService: LocationService,
    private programService: EducationProgramService,
    private majorService: MajorService
  ) { }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      code: ['', Validators.required],
      schoolType: [0],
      tuiTion: [0],
      website: [''],
      coverUrl: [''],
      description: [''],
      programs: [null, Validators.required],
      majors: [null, Validators.required],
      location: this.formBuilder.group({
        countryId: ['', Validators.required],
        cityId: ['', Validators.required],
        district: [''],
        ward: [''],
        street: ['']
      })
    });

    this.getSchool();
    this.getCountries();
    this.getCities();
    this.getPrograms();
    this.getMajors();
  }

  // convenience getter for easy access to form fields
  get f() { return this.editForm.controls; }

  get fLocation() { return (this.f.location as FormGroup).controls };

  private getSchool(): void {
    this.route.paramMap.pipe(
      map(params => this.schoolId = params.get('id')),
      filter(id => !!id),
      switchMap(id => this.schoolService.getSchool(id))
    ).subscribe(
      school => {
        this.editForm.patchValue(school);

        // Load depend
        this.loadSchoolPrograms(school.id);
        this.loadSchoolMajors(school.id);
      },
      error => console.error(error)
    );
  }

  private getCountries(): void {
    this.countries$ = this.locationService.getCountries();
  }

  private getCities(): void {
    this.cities$ = this.locationService.getCities();
  }

  private getPrograms(): void {
    this.programs$ = this.programService.getPrograms();
  }

  private getMajors(): void {
    this.majors$ = this.majorService.getMajors();
  }

  private loadSchoolPrograms(schoolId: string) {
    this.schoolService.getSchoolPrograms(schoolId).subscribe(
      programs => this.editForm.patchValue({ programs: programs }),
      error => console.log(error)
    );
  }

  private loadSchoolMajors(schoolId: string) {
    this.schoolService.getSchoolMajors(schoolId).subscribe(
      data => this.editForm.patchValue({ majors: data }),
      error => console.log(error)
    );
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.editForm.invalid) {
      return;
    }

    console.log(this.editForm.value);

    this.loading = true;
    if (this.schoolId) {
      this.updateSchool();
    } else {
      this.createSchool();
    }
  }

  private updateSchool(): void {
    this.schoolService.updateSchool(this.editForm.value).subscribe(
      () => this.router.navigate(['..'], { relativeTo: this.route }),
      error => {
        console.error(error);
        this.loading = false;
      });
  }

  private createSchool(): void {
    this.schoolService.createSchool(this.editForm.value).subscribe(
      schoolId => this.router.navigate(['../', schoolId], { relativeTo: this.route }),
      error => {
        console.error(error);
        this.loading = false;
      });
  }
}
