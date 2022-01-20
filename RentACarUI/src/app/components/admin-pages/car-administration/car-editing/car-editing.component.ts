import { Location } from "@angular/common";
import { Component, Input } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Car } from "src/app/models/car.model";
import { City } from "src/app/models/city.model";
import { Mark } from "src/app/models/mark.model";
import { CarService } from "src/app/services/car.service";
import { CityService } from "src/app/services/city.service";
import { MarkService } from "src/app/services/mark.service";

@Component({
    templateUrl:'./car-editing.component.html'
})
export class CarEditingComponent {
    @Input() public car: Car;

    public marks: Mark[];
    public cities: City[];

    constructor(private readonly _carService: CarService,
      private route: ActivatedRoute,
      private location: Location,
      private readonly _markService: MarkService,
      private readonly _cityService: CityService) { }
  
    public ngOnInit(): void {
      this.getCarById();
      this.getAllMarks();
      this.getAllCities();
    }
  
    getCarById(){
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this._carService.getCar(id)
        .subscribe(car => this.car = car);
    }
  
    updateCar(){
      this._carService.updateCar(this.car)
      .subscribe(() => this.goBack());
    }
  
    goBack(): void {
      this.location.back();
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