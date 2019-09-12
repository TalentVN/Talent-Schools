import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Input() currentPage: number;
  @Input() totalPages: number;
  @Output() onChangePage = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  changePage(page: number): void {
    if (page > 0 && page <= this.totalPages) {
      this.onChangePage.emit(page);
    }
  }

  makePaging(): Array<number> {
    if (this.currentPage < 1) {
      this.currentPage = 1;
    } else if (this.currentPage > this.totalPages) {
      this.currentPage = this.totalPages;
    }

    let startPage: number, endPage: number;
    if (this.totalPages <= 10) {
      // less than 10 total pages so show all
      startPage = 1;
      endPage = this.totalPages;
    } else {
      // more than 10 total pages so calculate start and end pages
      if (this.currentPage <= 6) {
        startPage = 1;
        endPage = 10;
      } else if (this.currentPage + 4 >= this.totalPages) {
        startPage = this.totalPages - 9;
        endPage = this.totalPages;
      } else {
        startPage = this.currentPage - 5;
        endPage = this.currentPage + 4;
      }
    }

    return Array.from(Array((endPage + 1) - startPage), (e, i) => startPage + i);
  }
}
