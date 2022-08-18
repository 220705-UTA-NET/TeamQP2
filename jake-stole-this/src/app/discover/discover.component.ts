import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Game } from '../../Game';

@Component({
  selector: 'app-discover',
  templateUrl: './discover.component.html',
  styleUrls: ['./discover.component.css']
})
export class DiscoverComponent implements OnInit {
  
  random_game: Game;
  games: Game[] = [];
  top_games: Game[] = [];
  random : number;

  constructor(private apiService: ApiService) { }


  ngOnInit(): void {
    this.apiService.getGames().subscribe(
      (games) => {this.games = games,
                  // console.log(this.games),
                  this.random = Math.floor(Math.random() * games.length),
                  this.random_game = this.games[this.random]
                  // console.log(this.random + "/" + this.games.length + ": " + this.random_game)
                });
    this.apiService.getTopGames().subscribe(
                  (games) => {this.top_games = games});
  }
}
