import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Mark } from 'src/app/models/mark.model';
import { MarkService } from 'src/app/services/mark.service';

@Component({
  selector: 'app-mark-administration',
  templateUrl: './mark-administration.component.html',
  styleUrls: ['./mark-administration.component.css']
})
export class MarkAdministrationComponent implements OnInit {

  marks: Mark[] = [];
  constructor(private markService: MarkService,
    private router: Router) { }
  ngOnInit(): void {
    this.getAllMarks();
  }

  getAllMarks(){
    this.markService.getAllMarks()
      .subscribe(marks => this.marks = marks);
  }

  deleteMark(id: number, i: number){
    this.markService.deleteMark(id).subscribe();
    this.marks.splice(i, 1);
  }

  redirectToCities(): void {
    this.router.navigate(['/admin/city']);
  }

  redirectToCars(): void {
    this.router.navigate(['/admin/car']);
  }

}
