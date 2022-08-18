import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { CoursesComponent } from './courses/courses.component';
import { CoursesService } from './Services/courses.service';
import { CourseComponent } from './courses/course/course.component';
import { GamesComponent } from './games/games.component';
import { SearchComponent } from './search/search.component';
import { GameComponent } from './games/game/game.component';
import { DiscoverComponent } from './discover/discover.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { ReviewComponent } from './reviews/review/review.component';


const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'Home', component: HomeComponent},
  {path: 'Game', component: GameComponent},
  {path: 'Discover', component: DiscoverComponent},
  {path: 'Games', component: GamesComponent},
  {path: 'About', component: AboutComponent},
  {path: 'Contact', component: ContactComponent},
  {path: 'Courses', component: CoursesComponent},
  {path: 'Course/:id', component: CourseComponent},
  {path: 'Reviews', component: ReviewsComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    CoursesComponent,
    CourseComponent,
    GamesComponent,
    SearchComponent,
    GameComponent,
    DiscoverComponent,
    ReviewsComponent,
    ReviewComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [CoursesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
