import { Component, OnInit } from '@angular/core';
import { Game } from '../../Game';
import { Review } from '../../Review';
import { ReviewPost } from '../../ReviewPost';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-review-game',
  templateUrl: './review-game.component.html',
  styleUrls: ['./review-game.component.css']
})
export class ReviewGameComponent implements OnInit {

  games: Game[] = [];
  gameTitles: string[] = [];
  game:Game;
  repeat : number[];
  repeat2 : number[];
  review: string;
  title: string;
  post:ReviewPost;
  constructor(private apiService : ApiService) {  }

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

  public uncheckedClick(i : number):void {
    this.repeat = new Array(this.repeat.length + i + 1);
    this.repeat2 = new Array(5 - this.repeat.length);
  }
  public checkedClick(i : number):void {
    this.repeat = new Array(i + 1);
    this.repeat2 = new Array(5 - this.repeat.length);
  }
  public newReview() {
    //console.log("button press: " + this.title + " " + this.repeat.length + " " + this.review);
    this.post = new ReviewPost(0, this.review, this.repeat.length, "gLance", this.title, "");
    this.apiService.addGameReview(this.post).subscribe(response => console.log(response));
  }
}
