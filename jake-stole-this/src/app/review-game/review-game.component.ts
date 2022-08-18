import { Component, OnInit } from '@angular/core';
import { Game } from '../../Game';
import { Review } from '../../Review';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-review-game',
  templateUrl: './review-game.component.html',
  styleUrls: ['./review-game.component.css']
})
export class ReviewGameComponent implements OnInit {

  games: Game[] = [];
  gameTitles: string[] = [];
  gameTitle:string;
  repeat : number[];
  repeat2 : number[];
  constructor(private apiService : ApiService) { }

  ngOnInit(): void {
    this.repeat = new Array<number>(0);
    this.repeat2 = new Array<number>(5);
    this.apiService.getGames().subscribe((games) => {
      this.games = games;
      this.games.forEach(element => {
        this.gameTitles.push(element.gameTitle);
      });
    });
  }

  public uncheckedClick(i : number):void{
    this.repeat = new Array(this.repeat.length + i + 1);
    this.repeat2 = new Array(5 - this.repeat.length);
  }
  public checkedClick(i : number):void{
    this.repeat = new Array(i + 1);
    this.repeat2 = new Array(5 - this.repeat.length);
  }

}
