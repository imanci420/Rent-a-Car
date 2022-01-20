import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { City } from 'src/app/models/city.model';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-city-creation',
  templateUrl: './city-creation.component.html',
  styleUrls: ['./city-creation.component.css']
})
export class CityCreationComponent implements OnInit {

  cityForm: City = new City();
  constructor(private cityService: CityService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createCity() {
    this.cityService.createCity(this.cityForm)
      .subscribe();
    this.router.navigateByUrl('/admin/city');
  }

}
