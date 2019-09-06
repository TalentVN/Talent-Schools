import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TimeAgoPipe } from 'time-ago-pipe';

import { RatingFormComponent } from './components/rating-form/rating-form.component';
import { RatingListComponent } from './components/rating-list/rating-list.component';
import { ConfirmModalComponent } from './components/modals/confirm-modal/confirm-modal.component';
import { PaginationComponent } from './components/pagination/pagination.component';


@NgModule({
  declarations: [
    RatingFormComponent, 
    RatingListComponent, 
    ConfirmModalComponent, 
    TimeAgoPipe, 
    PaginationComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    RatingFormComponent,
    RatingListComponent,
    PaginationComponent,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    TimeAgoPipe
  ],
  entryComponents: [ConfirmModalComponent]
})
export class SharedModule { }
