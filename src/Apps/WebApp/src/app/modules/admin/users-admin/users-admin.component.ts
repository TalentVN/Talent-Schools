import { Component, OnInit } from '@angular/core';

import { User } from 'src/app/shared/models/user.model';
import { UserService } from 'src/app/core/services/user.service';
import { PagingModel } from 'src/app/shared/models/Paging.model';

@Component({
  selector: 'app-users-admin',
  templateUrl: './users-admin.component.html',
  styleUrls: ['./users-admin.component.scss']
})
export class UsersAdminComponent implements OnInit {

  paging: PagingModel<User>;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getPagingUsers(1);
  }

  private getPagingUsers(currentPage: number): void {
    this.userService.getPagingUsers(currentPage).subscribe(
      paging => this.paging = paging,
      error => console.log(error)
    );
  }

  deleteUser(id: string): void {
    if (confirm("Are you sure to delete this user?")) {
      this.userService.deleteUser(id).subscribe(
        result => {
          if (result.succeeded) {
            this.getPagingUsers(this.paging.currentPage);
          } else {
            alert(result.errors[0].description);
          }
        },
        error => console.log(error)
      );
    }
  }
}
