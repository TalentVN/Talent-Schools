import { Component, OnInit } from '@angular/core';
import { SchoolModel } from 'src/app/shared/models/School.model';
import { ActivatedRoute } from '@angular/router';
import { SchoolService } from 'src/app/core/services/school.service';

@Component({
  selector: 'app-edit-school',
  templateUrl: './edit-school.component.html',
  styleUrls: ['./edit-school.component.scss']
})
export class EditSchoolComponent implements OnInit {

  school: SchoolModel;

  constructor(
    private router: ActivatedRoute,
    private schoolService: SchoolService
  ) { }

  ngOnInit() {
    this.school = new SchoolModel();
    this.getSchool();
  }

  private getSchool(): void {
    this.router.paramMap.subscribe(params => {
      const schoolId = params.get('id');

      if (schoolId) {
        this.schoolService.getSchool(schoolId).subscribe(
          school => {
            this.school = school;
          },
          error => console.log(error));
      }
    });
  }
}
