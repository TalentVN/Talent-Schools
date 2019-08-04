import { Component, OnInit } from '@angular/core';
import { SchoolModel } from 'src/app/shared/models/School.model';

@Component({
  selector: 'app-schools-admin',
  templateUrl: './schools-admin.component.html',
  styleUrls: ['./schools-admin.component.scss']
})
export class SchoolsAdminComponent implements OnInit {

  schools: SchoolModel[];

  constructor() { }

  ngOnInit() {
  }

}
