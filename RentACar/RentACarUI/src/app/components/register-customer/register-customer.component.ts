import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-register-customer',
  templateUrl: './register-customer.component.html',
  styleUrls: ['./register-customer.component.css']
})
export class RegisterCustomerComponent implements OnInit {

  customerForm: Customer = new Customer();
  constructor(private registerCustomerService: RegisterService,
    private router: Router) { }

  ngOnInit(): void {
  }

  register(){
    this.registerCustomerService.registerCustomer(this.customerForm)
    .subscribe( 
      () => this.router.navigateByUrl('login')
    );
  }

}
