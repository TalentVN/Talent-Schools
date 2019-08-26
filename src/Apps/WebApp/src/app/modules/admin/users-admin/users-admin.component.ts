import { Component, OnInit } from '@angular/core';

import { User } from 'src/app/shared/models/user.model';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-users-admin',
  templateUrl: './users-admin.component.html',
  styleUrls: ['./users-admin.component.scss']
})
export class UsersAdminComponent implements OnInit {

  users: User[];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers(): void {
    this.userService.getUsers().subscribe(
      users => this.users = users,
      error => console.log(error)
    );
  }

  deleteUser(id: string): void {
    if (confirm("Are you sure to delete this user?")) {
      this.userService.deleteUser(id).subscribe(
        result => {
          if (result.succeeded) {
            this.users = this.users.filter(s => s.id !== id);
          } else {
            alert(result.errors[0].description);
          }
        },
        error => console.log(error)
      );
    }
  }
}
