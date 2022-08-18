import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from '../Review';
import { Game } from '../Game';
import { ReviewPost } from '../ReviewPost';
import { Rating } from '../Rating';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'https://demowebapp-jake.azurewebsites.net/api';

  constructor(private http: HttpClient) { }
  getGames(): Observable<Game[]> {
    const url = `${this.apiUrl}/Game`;
    return this.http.get<Game[]>(url/*, game_name*/);
  }

  getReviews(): Observable<Review[]> {
    const url = `${this.apiUrl}/Reviews`;
    return this.http.get<Review[]>(url/*, game_name*/);
  }

  getGameRating(game: string): Observable<Rating> {
    const url = `${this.apiUrl}/Reviews/AverageRating?game=${game}`;
    return this.http.get<Rating>(url/*, game_name*/);
  }

  deleteGameReview(review: Review): Observable<Review> {
    const url = `${this.apiUrl}/Reviews/${review.id}`;
    return this.http.delete<Review>(url);
  }

  updateGameReview(review: Review): Observable<Review> {
    const url = `${this.apiUrl}/Reviews/${review.id}`;
    return this.http.put<Review>(url, review, httpOptions);
  }

  addGameReview(review: ReviewPost): Observable<ReviewPost> {
    const url = `${this.apiUrl}/Reviews/insertReview/`;
    const post = { id: 69, review: "gay", starRating: 5, userName: "SexyJakey", gameTitle: "Brandonlands: The Handsome Collection", reviewDate: "2022-08-17T18:19:24.35" };
    console.log("Ran post with " + JSON.stringify(post));
    return this.http.post<ReviewPost>(url, JSON.stringify(post), httpOptions);
  }
}
