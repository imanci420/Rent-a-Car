import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mark } from '../models/mark.model';

@Injectable({
  providedIn: 'root'
})
export class MarkService {

  readonly url = 'api/mark';
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getAllMarks(): Observable<Mark[]>{
    return this.http.get<Mark[]>(this.url);
  }

  getMark(id: number): Observable<Mark> {
    return this.http.get<Mark>(`${this.url}/${id}`);
  }

  createMark(mark: Mark): Observable<Mark> {
    return this.http.post<Mark>(`${this.url}/create`, mark, this.httpOptions);
  }

  deleteMark(id: number): Observable<Mark> {
    return this.http.delete<Mark>(`${this.url}/delete/${id}`);
  }

  updateMark(mark: Mark): Observable<Mark> {
    return this.http.put<Mark>(`${this.url}/update`, mark);
  }

}
