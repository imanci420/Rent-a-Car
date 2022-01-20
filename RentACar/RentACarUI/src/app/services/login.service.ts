import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginDto } from '../models/login-dto.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  readonly url = '/api/login'
  constructor(private http: HttpClient) { }

  login(dto: LoginDto){
    return this.http.post<any>(this.url, dto);
  }
}
