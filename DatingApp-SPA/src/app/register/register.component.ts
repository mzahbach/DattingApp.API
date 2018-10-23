import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AutchService } from '../_services/autch.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(private authServices: AutchService , private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authServices.register(this.model).subscribe( () => {
      this.alertify.success ('sa7it tawa ta5ra fih');
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
    this.alertify.warning('barra rawa7 nayek');
  }

}
