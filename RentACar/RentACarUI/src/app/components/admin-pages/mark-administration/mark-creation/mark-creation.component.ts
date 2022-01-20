import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Mark } from 'src/app/models/mark.model';
import { MarkService } from 'src/app/services/mark.service';

@Component({
  selector: 'app-mark-creation',
  templateUrl: './mark-creation.component.html',
  styleUrls: ['./mark-creation.component.css']
})
export class MarkCreationComponent implements OnInit {

  markForm: Mark = new Mark();
  constructor(private markService: MarkService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createMark() {
    this.markService.createCity(this.markForm)
      .subscribe();
    this.router.navigateByUrl('/admin/mark');
  }

}
