import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-rating-form',
  templateUrl: './rating-form.component.html',
  styleUrls: ['./rating-form.component.scss']
})
export class RatingFormComponent implements OnInit {

  @Input() schoolId: string;

  constructor() { }

  ngOnInit() {
  }

}
