import { Component, OnInit, Input } from '@angular/core';
import { UserModel } from 'src/app/models/userModel';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() user: UserModel;

  constructor() { }

  ngOnInit() {
  }

}
