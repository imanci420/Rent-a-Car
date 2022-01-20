import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Car } from '../models/car.model';
import { SearchDto } from '../models/search-dto.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  private composeQueryString(object: any): string {
    let result = '';
    let isFirst = true;
    if (object) {
      Object.keys(object)
        .filter(key => object[key] !== null && object[key] !== undefined)
        .forEach(key => {
          let value = object[key];
          if (value instanceof Date) {
            value = value.toISOString();
          }
          if (isFirst) {
            result = '?' + key + '=' + value;
            isFirst = false;
          } else {
            result += '&' + key + '=' + value;
          }
        });
    }
    return result;
  }

  public search(searchDto: SearchDto): Observable<Car[]> {
    let query = "/api/search/car";
    query += this.composeQueryString(searchDto);
    return this.http.get<Car[]>(query);
  }
}
