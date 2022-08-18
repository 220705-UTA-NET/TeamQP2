import { Component, Input, OnInit } from '@angular/core';
import { Review } from '../../../Review';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  @Input() review:Review;
  date : string;
  repeat : number[];
  repeat2 : number[];
  constructor() { }

  ngOnInit(): void {
        this.repeat = new Array<number>(this.review.starRating);
        this.repeat2 = new Array<number>(5 - this.review.starRating);
        this.date = this.review.reviewDate.substring(0,10);
  }

}
