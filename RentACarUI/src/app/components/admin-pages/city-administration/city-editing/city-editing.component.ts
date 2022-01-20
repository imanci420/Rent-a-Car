import { Component, Input, OnInit } from '@angular/core';
import { City } from 'src/app/models/city.model';
import { CityService } from 'src/app/services/city.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-city-editing',
  templateUrl: './city-editing.component.html',
  styleUrls: ['./city-editing.component.css']
})
export class CityEditingComponent implements OnInit {

  @Input() city: City;
  constructor(private cityService: CityService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.getCity();
  }

  getCity(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.cityService.getCity(id)
      .subscribe(city => this.city = city);
  }

  updateCity(){
    this.cityService.updateCity(this.city)
    .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }
}

