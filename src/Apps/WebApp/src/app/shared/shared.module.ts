import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { RatingFormComponent } from './components/rating-form/rating-form.component';


@NgModule({
  declarations: [RatingFormComponent],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule
  ],
  exports: [
    RatingFormComponent,
    NgbModule,
    FormsModule
  ]
})
export class SharedModule { }
