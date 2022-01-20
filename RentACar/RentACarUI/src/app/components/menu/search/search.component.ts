import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car.model';
import { SearchDto } from 'src/app/models/search-dto.model';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchDto: SearchDto = new SearchDto();
  cars: Car[];

  constructor(private searchService: SearchService) { }

  ngOnInit(): void {

  }

  search(){
    this.searchService.search(this.searchDto)
    .subscribe(games => this.cars = games);
  this.searchDto = new SearchDto();
  }

}
