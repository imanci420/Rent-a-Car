import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  readonly url = 'api/city';
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getAllCities(): Observable<City[]>{
    return this.http.get<City[]>(this.url);
  }

  createCity(city: City): Observable<City> {
    return this.http.post<City>(`${this.url}/create`, city, this.httpOptions);
  }

  deleteCity(id: number): Observable<City> {
    return this.http.delete<City>(`${this.url}/delete/${id}`);
  }

  getCity(id: number): Observable<City> {
    return this.http.get<City>(`${this.url}/${id}`);
  }

  updateCity(city: City): Observable<any> {
    return this.http.put<any>(`${this.url}/update`, city);
  }
}
