import { Component, OnInit, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../core/services/authentication.service';

@Component({
  selector: 'app-rating-form',
  templateUrl: './rating-form.component.html',
  styleUrls: ['./rating-form.component.scss']
})
export class RatingFormComponent implements OnInit {

  @Input() schoolId: string;

  ctrl = new FormControl(null, Validators.required);

  constructor(
    private authService: AuthenticationService
  ) { }

  ngOnInit() {
  }

  public submitRating(): void {
    this.checkLogin();
  }

  public checkLogin(): void {
    if (!this.authService.isLogin()) {
      // popup to login
      alert('popup to login if not');
    }
  }

}
