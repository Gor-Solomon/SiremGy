import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/Alertify.service';
import { Router } from '@angular/router';

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



  constructor(private authService: AuthService,
              private alertifyService: AlertifyService,
              private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertifyService.success('logged in successfully');
    }, error => {
      this.alertifyService.error(error);
    }, () => {
      this.router.navigate(['/encounters']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/home']).finally(() => {
        this.alertifyService.success('logged out');
    });

  }

  getLogedInWelcomeMessage(): string {
    return 'Welcome ' + this.authService.getUserInfo().given_name;
  }

}
