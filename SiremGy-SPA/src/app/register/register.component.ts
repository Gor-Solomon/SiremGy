import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { RegisterModel } from '../models/RegisterModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  model: RegisterModel;

  constructor(private authenticationService: AuthService) { }

  ngOnInit() {
    this.model = new RegisterModel();
  }

  register() {
    this.authenticationService.Register(this.model).subscribe( () => {
      this.cancel();
      alert('Registration succeeded');
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
