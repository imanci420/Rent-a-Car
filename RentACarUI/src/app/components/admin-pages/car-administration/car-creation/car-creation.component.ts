import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Car } from "src/app/models/car.model";
import { City } from "src/app/models/city.model";
import { Mark } from "src/app/models/mark.model";
import { CarService } from "src/app/services/car.service";
import { CityService } from "src/app/services/city.service";
import { MarkService } from "src/app/services/mark.service";

@Component({
    templateUrl: './car-creation.component.html'
})
export class CarCreationComponent implements OnInit {
    public carForm: Car = new Car();

    public marks: Mark[];
    public cities: City[];

    constructor(private readonly _carService: CarService,
        private router: Router,
        private readonly _markService: MarkService,
        private readonly _cityService: CityService) { }

    ngOnInit(): void {
        this.getAllMarks();
        this.getAllCities();
    }

    public createCar(): void {
        this._carService.createCar(this.carForm)
            .subscribe(() => {
                this.router.navigateByUrl('/admin/car');
            });
    }


    getAllMarks(): void {
        this._markService.getAllMarks().subscribe((marks) => {
            this.marks = marks;
        })
    }

    getAllCities(): void {
        this._cityService.getAllCities().subscribe((cities) => {
            this.cities = cities;
        })
    }
}