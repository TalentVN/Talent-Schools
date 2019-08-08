import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.scss']
})
export class ConfirmModalComponent implements OnInit {
  @Input() title;
  @Input() body;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  public Ok() {

  }

  public Cancel() {

  }

}
