import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  readonly url = "api/register";
  constructor(private http: HttpClient) { }

  registerCustomer(form: Customer){
    return this.http.post<any>(this.url, form);
  }
}
