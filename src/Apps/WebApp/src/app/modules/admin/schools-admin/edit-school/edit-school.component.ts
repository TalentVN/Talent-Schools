import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { map, filter, switchMap } from 'rxjs/operators';

import { SchoolService } from 'src/app/core/services/school.service';
import { SchoolTypeOption } from 'src/app/shared/options/school-type.option';
import { CityModel } from 'src/app/shared/models/City.model';
import { CountryModel } from 'src/app/shared/models/Country.model';
import { LocationService } from 'src/app/core/services/location.service';

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
  countries: CountryModel[];
  cities: CityModel[];

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private schoolService: SchoolService,
    private locationService: LocationService
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
      school => this.editForm.patchValue(school),
      error => console.error(error)
    );
  }

  private getCountries(): void {
    this.locationService.getCountries().subscribe(
      countries => {
        this.countries = countries;

        if (!this.schoolId) {
          this.editForm.patchValue({
            location: {
              countryId: countries[0].id
            }
          });
        }
      },
      error => console.error(error)
    );
  }

  private getCities(): void {
    this.locationService.getCities().subscribe(
      cities => {
        this.cities = cities;

        if (!this.schoolId) {
          this.editForm.patchValue({
            location: {
              cityId: cities[0].id
            }
          });
        }
      },
      error => console.error(error)
    );
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.editForm.invalid) {
      return;
    }

    this.loading = true;
    if (this.schoolId) {
      this.updateSchool();
    } else {
      this.createSchool();
    }
  }

  private updateSchool(): void {
    this.schoolService.updateSchool(this.editForm.value).subscribe(
      () => this.router.navigate(['admin']),
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
