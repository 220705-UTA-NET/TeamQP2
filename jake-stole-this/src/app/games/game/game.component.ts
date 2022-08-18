import { Component, Input, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { Game } from '../../../Game';
import { Rating } from '../../../Rating';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  @Input() game: Game;
  rating: Rating;
  numberRating: number;
  title: string;
  repeat : number[];
  repeat2 : number[];
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    console.log(this.game);
    this.title= this.game.gameTitle;
    this.numberRating = 0;
    this.repeat = new Array<number>(0);
    this.repeat2 = new Array<number>(5);
    this.apiService.getGameRating(this.title).subscribe((rating) => {
      this.rating = rating;
      this.numberRating = this.rating.averageRating;
      console.log("number: " + this.numberRating);
      this.repeat = new Array<number>(Math.round(this.rating.averageRating));
      this.repeat2 = new Array<number>(5 - Math.round(this.rating.averageRating));
    });
  }
}
