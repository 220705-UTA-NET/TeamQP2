import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CoursesService } from './Services/courses.service';
import { GamesComponent } from './games/games.component';
import { SearchComponent } from './search/search.component';
import { GameComponent } from './games/game/game.component';
import { DiscoverComponent } from './discover/discover.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { ReviewComponent } from './reviews/review/review.component';
import { ReviewGameComponent } from './review-game/review-game.component';


const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'Home', component: HomeComponent},
  {path: 'Game', component: GameComponent},
  {path: 'Discover', component: DiscoverComponent},
  {path: 'Games', component: GamesComponent},
  {path: 'Reviews', component: ReviewsComponent},
  {path: 'ReviewGame', component: ReviewGameComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GamesComponent,
    SearchComponent,
    GameComponent,
    DiscoverComponent,
    ReviewsComponent,
    ReviewComponent,
    ReviewGameComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [CoursesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
