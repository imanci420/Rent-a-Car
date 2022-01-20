import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    if (!this.isAdminRole()) {
      this.router.navigate(['/login']);
    }
  }

  isAdminRole(): boolean {
    let token: any = localStorage.getItem('token');
    let decodedJWT = JSON.parse(window.atob(token.split('.')[1]));

    if (decodedJWT.role == "admin") {
      return true;
    }
    else {
      return false;
    }
  }

}
