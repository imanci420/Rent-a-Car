import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/models/car.model';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-administration',
  templateUrl: './car-administration.component.html'
})
export class CarAdministrationComponent implements OnInit {

  public cars: Car[] = [];
  
  constructor(private readonly _carService: CarService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllCars();
  }

  getAllCars(){
    this._carService.getAllCars()
      .subscribe(cars => this.cars = cars);
  }

  deleteCar(id: number, i: number){
    this._carService.deleteCar(id).subscribe();
    this.cars.splice(i, 1);
  }

  redirectToCities(): void {
    this.router.navigate(['/admin/city']);
  }

  redirectToMarks(): void {
    this.router.navigate(['/admin/marks']);
  }

}
