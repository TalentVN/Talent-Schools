import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { SchoolModel } from 'src/app/shared/models/School.model';
import { SchoolService } from 'src/app/core/services/school.service';
import { SchoolTypeOption } from 'src/app/shared/options/school-type.option';
import { CityModel } from 'src/app/shared/models/City.model';
import { CountryModel } from 'src/app/shared/models/Country.model';
import { LocationService } from 'src/app/core/services/location.service';
import { LocationModel } from 'src/app/shared/models/Location.model';

@Component({
  selector: 'app-edit-school',
  templateUrl: './edit-school.component.html',
  styleUrls: ['./edit-school.component.scss']
})
export class EditSchoolComponent implements OnInit {

  school: SchoolModel;
  schoolTypes = SchoolTypeOption;
  countries: CountryModel[];
  cities: CityModel[];

  constructor(
    private router: ActivatedRoute,
    private location: Location,
    private schoolService: SchoolService,
    private locationService: LocationService
  ) { }

  ngOnInit() {
    this.school = new SchoolModel();
    this.school.location = new LocationModel();

    this.getSchool();
    this.getCountries();
    this.getCities();
  }

  private getSchool(): void {
    this.router.paramMap.subscribe(params => {
      const schoolId = params.get('id');

      if (schoolId) {
        this.schoolService.getSchool(schoolId).subscribe(
          school => this.school = school,
          error => console.log(error)
        );
      }
    });
  }

  private getCountries(): void {
    this.locationService.getCountries().subscribe(
      countries => this.countries = countries,
      error => console.log(error)
    );
  }

  private getCities(): void {
    this.locationService.getCities().subscribe(
      cities => this.cities = cities,
      error => console.log(error)
    );
  }

  save(): void {
    if (this.school.id) {
      this.updateSchool();
    } else {
      this.createSchool();
    }
  }

  private updateSchool(): void {
    this.schoolService.updateSchool(this.school).subscribe(
      () => this.location.back(),
      error => console.log(error)
    );
  }

  private createSchool(): void {
    this.schoolService.createSchool(this.school).subscribe(
      () => this.location.back(),
      error => console.log(error)
    );
  }
}
