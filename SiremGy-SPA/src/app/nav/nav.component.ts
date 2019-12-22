import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {
    Email: '',
    Password: '',
  };

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login() {
    console.log('Loging....');
    console.log(this.model.Email);
    console.log(this.model.Password);
    this.authService.login(this.model).subscribe(next => {
      console.log('Login successfully');
    }, error => {
        console.log(error);
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
