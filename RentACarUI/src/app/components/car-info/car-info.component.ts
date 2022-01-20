import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Car } from "src/app/models/car.model";
import { City } from "src/app/models/city.model";
import { Mark } from "src/app/models/mark.model";
import { Rent } from "src/app/models/rent.model";
import { CarService } from "src/app/services/car.service";
import { CityService } from "src/app/services/city.service";
import { DecodedTokenService } from "src/app/services/decoded-token.service";
import { MarkService } from "src/app/services/mark.service";
import { RentService } from "src/app/services/rent.service";

@Component({
    templateUrl: './car-info.component.html',
    styleUrls: ['./car-info.component.scss']
})
export class CarInfoComponent implements OnInit {
    public car: Car;
    public mark: Mark;
    public city: City;
    public rentPrice: number;
    public minDate: string;
    public currentRent: Rent;
    public userId: number;

    private _rentEndDate: Date;

    public get rentEndDate(): Date {
        return this._rentEndDate;
    }

    public set rentEndDate(value) {
        this._rentEndDate = value;
        this.setRentPrice(this._rentEndDate);
    }

    public constructor(private readonly _carService: CarService,
        private readonly _markService: MarkService,
        private readonly _cityService: CityService,
        private readonly _route: ActivatedRoute,
        private readonly _decodedTokenService: DecodedTokenService,
        private readonly _rentService: RentService) {

    }

    public ngOnInit(): void {
        this.getCarById();
        this.userId = this._decodedTokenService.decodedToken.userId;

        let tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        this.minDate = `${tomorrow.getFullYear()}-${tomorrow.getMonth() + 1}-${tomorrow.getDate()}`
        this.rentEndDate = new Date(this.minDate);
    }

    public getCarRent(): void {
        this._rentService.getCarRent(this.car.id).subscribe(
            (rent: Rent) => {
                this.currentRent = rent;
                if(this.currentRent.rentTime.getTime() < new Date().getTime()) {
                    this.car.status = true;
                    this._carService.changeCarStatus(this.car.id, this.car.status).subscribe();
                }
            })
    }

    getCarById() {
        const id = Number(this._route.snapshot.paramMap.get('id'));
        this._carService.getCar(id)
            .subscribe(car => {
                this.car = car
                this._markService.getMark(car.markId).subscribe((mark) => {
                    this.mark = mark;
                })

                this._cityService.getCity(car.cityId).subscribe((city) => {
                    this.city = city;
                })

                this.getCarRent();
                this.setRentPrice(this.rentEndDate);
            });
    }

    onRentClick(): void {
        const rent: Rent = {
            customerId: this.userId,
            carId: this.car.id,
            rentCost: this.rentPrice,
            rentTime: this.rentEndDate
        };

        this._rentService.rent(rent).subscribe(() => {
            this.car.status = false;
        });

    }

    setRentPrice(rentEndDate: Date): void {
        if (!this.rentEndDate || !this.car) {
            return;
        }

        const now = new Date();
        const diffInMs = rentEndDate.getTime() - now.getTime();
        const hours = diffInMs / 1000 / 60 / 60;
        this.rentPrice = hours * this.car.pricePerHour;
    }

    extendRentPeriod(): void {
        this._rentService.extendRentPeriod(this.currentRent.id, this.currentRent.rentTime).subscribe();
    }
}