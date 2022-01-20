import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDto } from 'src/app/models/login-dto.model';
import { DecodedTokenService } from 'src/app/services/decoded-token.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginDto = new LoginDto();
  constructor(private loginService: LoginService,
    private router: Router,
    private readonly _decodedTokenService: DecodedTokenService) { }

  ngOnInit(): void {
  }

  login(){
    this.loginService.login(this.loginDto)
    .subscribe(
      res => {
        localStorage.setItem('token', res.token);
        let decodedJWT = JSON.parse(window.atob(res.token.split('.')[1]));

        this._decodedTokenService.decodedToken = decodedJWT;

        if (decodedJWT.role == "admin") {
          this.router.navigateByUrl('admin');
        }
        else {
          this.router.navigateByUrl('search');
        }
      },
      err => { console.log(err); }
    )
  }
}
