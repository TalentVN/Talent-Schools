import { Component, OnInit, Input } from '@angular/core';
import { RatingModel } from '../../models/Rating.model';

@Component({
  selector: 'app-rating-list',
  templateUrl: './rating-list.component.html',
  styleUrls: ['./rating-list.component.scss']
})
export class RatingListComponent implements OnInit {

  @Input() ratings: RatingModel[];

  constructor() { }

  ngOnInit() {
    // Mock ratings
  }

}
