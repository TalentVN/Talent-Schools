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

  private schoolId: string;
  school: SchoolModel;

  constructor(
    private router: ActivatedRoute,
    private schoolService: SchoolService
  ) { }

  ngOnInit() {
    this.school = new SchoolModel();
    this.getSchool();
  }

  getSchool(): void {
    this.router.paramMap.subscribe(params => {
      this.schoolId = params.get('id');

      if (this.schoolId) {
        this.schoolService.getSchool(this.schoolId)
          .subscribe(school => this.school = school);
      }
    });
  }
}
