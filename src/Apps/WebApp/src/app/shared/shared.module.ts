import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { RatingFormComponent } from './components/rating-form/rating-form.component';
import { RatingListComponent } from './components/rating-list/rating-list.component';
import { ConfirmModalComponent } from './components/modals/confirm-modal/confirm-modal.component';


@NgModule({
  declarations: [RatingFormComponent, RatingListComponent, ConfirmModalComponent],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    RatingFormComponent,
    RatingListComponent,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  entryComponents: [ConfirmModalComponent]
})
export class SharedModule { }
