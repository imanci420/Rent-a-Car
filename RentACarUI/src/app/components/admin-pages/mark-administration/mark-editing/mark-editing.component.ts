import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Mark } from 'src/app/models/mark.model';
import { MarkService } from 'src/app/services/mark.service';

@Component({
  selector: 'app-mark-editing',
  templateUrl: './mark-editing.component.html',
  styleUrls: ['./mark-editing.component.css']
})
export class MarkEditingComponent implements OnInit {

  @Input() mark: Mark;
  constructor(private markService: MarkService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.getMarkById();
  }

  getMarkById(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.markService.getMark(id)
      .subscribe(mark => this.mark = mark);
  }

  updateMark(){
    this.markService.updateMark(this.mark)
    .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }

}
