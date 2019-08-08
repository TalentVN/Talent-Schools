import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { Router, ActivatedRoute, RouterStateSnapshot } from '@angular/router';

import { AuthenticationService } from '../../../core/services/authentication.service';
import { RatingService } from '../../../core/services/rating.service';
import { CreateRatingModel } from '../../models/CreateRating.model';
import { ConfirmModalComponent } from '../modals/confirm-modal/confirm-modal.component';
import { RatingModel } from '../../models/Rating.model';

@Component({
  selector: 'app-rating-form',
  templateUrl: './rating-form.component.html',
  styleUrls: ['./rating-form.component.scss']
})
export class RatingFormComponent implements OnInit {

  @Input() schoolId: string;
  @Input() ratingType: number;

  @Output() rated = new EventEmitter<boolean>();

  public rating: CreateRatingModel = new CreateRatingModel();

  public ratingForm: FormGroup;
  modalOption: NgbModalOptions = {};

  constructor(
    private authService: AuthenticationService,
    private ratingService: RatingService,
    private modalService: NgbModal,
    private router: Router,
    private activatedRoute: ActivatedRoute,
  ) {
    this.subcribeQueryParams();
  }

  ngOnInit() {
    this.ratingForm = new FormGroup({
      comment: new FormControl(this.rating.value, [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(200)
      ]),
      value: new FormControl(this.rating.value, [
        Validators.required
      ]),
    });
  }

  get f() { return this.ratingForm.controls; }

  private subcribeQueryParams() {
    this.activatedRoute.queryParamMap.subscribe(params => {
      this.ratingType = + params.get('filter');
    });
  }

  public submitRating(): void {

    // Require login before submit
    if (this.checkLogin()) {
      this.confirmedSubmit();
    }
  }

  private checkLogin(): boolean {
    if (!this.authService.isLogin()) {

      this.modalOption.backdrop = 'static';
      this.modalOption.keyboard = false;

      // popup to login
      const modalRef = this.modalService.open(ConfirmModalComponent, this.modalOption).result.then((result) => {
        if (result === 'Ok') {
          this.router.navigate(['/login'], { queryParams: { returnUrl: this.router.routerState.snapshot.url } });
        }
      }, (reason) => {
        console.log(`Dismissed ${reason}`);
      });

      return false;
    } else { return true; }
  }

  private confirmedSubmit() {
    this.rating.comment = this.f.comment.value;
    this.rating.value = this.f.value.value;
    this.rating.ratingType = this.ratingType;
    this.rating.userId = this.authService.currentUserValue.id;
    this.rating.schoolId = this.schoolId;

    this.ratingService.createRatings(this.rating)
      .subscribe(
        data => {
          alert('Thank you!');

          this.ratingForm.reset();

          this.rated.emit(true);
        },
        error => {
          console.log(error);
        }
      );
  }

}
