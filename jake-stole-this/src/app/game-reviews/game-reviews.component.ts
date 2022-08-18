import { Component, Input, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Review } from '../../Review';
import { Game } from 'src/Game';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-game-reviews',
  templateUrl: './game-reviews.component.html',
  styleUrls: ['./game-reviews.component.css']
})
export class GameReviewsComponent implements OnInit {
  
  name: string;
  reviews: Review[] = [];

  constructor(private apiService: ApiService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.name = this.route.snapshot.params['name'];
    console.log("routed to: " + this.name);
    this.apiService.getGameReviews(this.name).subscribe((reviews) => {this.reviews = reviews});
  }

}

