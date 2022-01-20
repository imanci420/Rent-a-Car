import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthenticationService,
    private router: Router) { }

  canActivate(): boolean {
    let token: any = localStorage.getItem('token');
    let decodedJWT = JSON.parse(window.atob(token.split('.')[1]));

    if (decodedJWT.role == "admin") {
      return true;
    }
    else {
      this.router.navigate(['/login']);
      return false;
    }
  }
  
}
