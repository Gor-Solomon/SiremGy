import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  registerMode = false;
  countries: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCountries();
  }

  registerToggle() {
    this.registerMode = true;
  }

  getCountries() {
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => {
        this.countries = response;
      },
      error => {
        console.log(error);
      }
    );
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
