import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from '../Review';
import { Game } from '../Game';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'http://localhost:5000/';

  constructor(private http: HttpClient) {}
  getGames(): Observable<Game[]> {
    const url = `${this.apiUrl}/game`;
    return this.http.get<Game[]>(url/*, game_name*/);
  }

  getGameReview(): Observable<Review[]> {
    const url = `${this.apiUrl}/reviews`;
    return this.http.get<Review[]>(url/*, game_name*/);
  }

  deleteGameReview(review: Review): Observable<Review> {
    const url = `${this.apiUrl}/reviews/${review.id}`;
    return this.http.delete<Review>(url);
  }

  updateGameReview(review: Review): Observable<Review> {
    const url = `${this.apiUrl}/reviews/${review.id}`;
    return this.http.put<Review>(url, review, httpOptions);
  }

  addGameReview(review: Review): Observable<Review> {
    const url = `${this.apiUrl}/reviews`;
    return this.http.post<Review>(url, review, httpOptions);
  }
}
