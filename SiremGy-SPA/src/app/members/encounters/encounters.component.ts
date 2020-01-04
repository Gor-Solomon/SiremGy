import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/userModel';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/Alertify.service';

@Component({
  selector: 'app-encounters',
  templateUrl: './encounters.component.html',
  styleUrls: ['./encounters.component.css']
})
export class EncountersComponent implements OnInit {
  users: UserModel[];

  constructor(private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
     this.userService.getUsers().subscribe( users =>{
       this.users = users;
     }, error => {
       this.alertify.error(error);
     });
  }

}
