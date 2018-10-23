import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AutchService } from '../_services/autch.service';
import { AlertifyService } from '../_services/alertify.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private autchService: AutchService,  private router: Router,
    private alertify: AlertifyService){}
  canActivate(): boolean {
    if (this.autchService.loggedIn()) {
      return true;
    }

    this.alertify.error('Min 4ire mé tkaser zbek barcha mekch bech tet3ada');
    this.router.navigate(['/home']);
    return  false;


  }
}
