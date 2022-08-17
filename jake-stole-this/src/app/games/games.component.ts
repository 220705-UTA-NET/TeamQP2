import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Game } from '../../Game';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
  
  games: Game[] = [];

  constructor(private apiService: ApiService) { }


  ngOnInit(): void {
    this.apiService.getGames().subscribe((games) => {this.games = games, console.log(this.games)});
  }
}
