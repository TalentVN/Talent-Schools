import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { RatingFormComponent } from './components/rating-form/rating-form.component';
import { RatingListComponent } from './components/rating-list/rating-list.component';


@NgModule({
  declarations: [RatingFormComponent, RatingListComponent],
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
  ]
})
export class SharedModule { }
