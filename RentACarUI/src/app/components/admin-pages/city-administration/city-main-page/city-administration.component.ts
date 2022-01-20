import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { City } from 'src/app/models/city.model';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-city-administration',
  templateUrl: './city-administration.component.html',
  styleUrls: ['./city-administration.component.css']
})
export class CityAdministrationComponent implements OnInit {

  cities: City[] = [];
  constructor(private cityService: CityService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllCities();
  }

  getAllCities(): void {
    this.cityService.getAllCities()
      .subscribe(cities => this.cities = cities);
  }

  deleteCity(id: number, index: number): void {
    this.cityService.deleteCity(id).subscribe();
    this.cities.splice(index, 1);
  }

  redirectToMarks(): void {
    this.router.navigate(['/admin/mark']);
  }

  redirectToCars(): void {
    this.router.navigate(['/admin/car']);
  }

}
