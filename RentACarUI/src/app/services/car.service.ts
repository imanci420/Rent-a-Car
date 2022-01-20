import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Car } from "../models/car.model";

@Injectable({
    providedIn: 'root'
})
export class CarService {
    private readonly _baseUrl = "api/car";

    public constructor(private readonly _httpClient: HttpClient){

    }

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }
    
      getAllCars(): Observable<Car[]>{
        return this._httpClient.get<Car[]>(this._baseUrl);
      }
    
      createCar(car: Car): Observable<Car> {
        return this._httpClient.post<Car>(`${this._baseUrl}/create`, car, this.httpOptions);
      }
    
      deleteCar(id: number): Observable<Car> {
        return this._httpClient.delete<Car>(`${this._baseUrl}/delete/${id}`);
      }
    
      getCar(id: number): Observable<Car> {
        return this._httpClient.get<Car>(`${this._baseUrl}/${id}`);
      }
    
      updateCar(car: Car): Observable<any> {
        return this._httpClient.put<any>(`${this._baseUrl}/update`, car);
      }

      changeCarStatus(carId: number, newStatus: boolean): Observable<any> {
          return this._httpClient.put<void>(`${this._baseUrl}/status/${carId}`, newStatus);
      }
}