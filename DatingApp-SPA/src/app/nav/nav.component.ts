import { Component, OnInit } from '@angular/core';
import { AutchService } from '../_services/autch.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AutchService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('hak d5alet ya3tik sa7a 5rite fihe');
    }, error => {
      this.alertify.error(error);
    });
  }


  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('o5rej nayek ezreb rou7ek :p');
  }

}
