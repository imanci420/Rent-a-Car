import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }
  loggedIn() {
    return !!localStorage.getItem('token');
  }
}
