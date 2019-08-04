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
    this.ratings = [
      {
        id: '',
        comment: 'Trường học tốt nhất tôi từng học',
        ratingType: 1,
        value: 5,
        ratingOwner: 'Văn Nhật'
      },
      {
        id: '',
        comment: 'Trường học tốt nhất tôi từng học',
        ratingType: 1,
        value: 4,
        ratingOwner: 'Văn Nhật'
      }, {
        id: '',
        comment: 'Trường học tốt nhất tôi từng học',
        ratingType: 1,
        value: 3,
        ratingOwner: 'Văn Nhật'
      }
    ];
  }

}
