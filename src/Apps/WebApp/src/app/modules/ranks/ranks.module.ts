import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RanksComponent } from './ranks.component';
import { RanksRoutingModule } from './ranks-routing.module';


@NgModule({
  declarations: [RanksComponent],
  imports: [
    CommonModule,
    RanksRoutingModule
  ]
})
export class RanksModule { }
