import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
  
  constructor(private apiService: ApiService) { }

  games = [];

  ngOnInit(): void {
    this.apiService.getGames().subscribe((games) => (this.games = games));
  }

}
