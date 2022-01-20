import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Rent } from "../models/rent.model";

@Injectable({
    providedIn: 'root'
})
export class RentService {
    private readonly _baseUrl: string = 'api/rent';
    constructor(private readonly _httpClient: HttpClient){

    }

    public rent(rent: Rent): Observable<void> {
        return this._httpClient.post<void>(this._baseUrl, rent);
    }

    public getCarRent(carId: number): Observable<Rent> {
        return this._httpClient.get<Rent>(`${this._baseUrl}/car/${carId}`);
    }

    public extendRentPeriod(rentId: number | undefined, rentTime: Date) {
        return this._httpClient.put<void>(`${this._baseUrl}/extendRent/${rentId}`, rentTime);
    }
}