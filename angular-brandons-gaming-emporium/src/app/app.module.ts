import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService } from './in-memory-data.service';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { AddGameComponent } from './add-game/add-game.component';
import { GameReviewComponent } from './game-review/game-review.component';
import { FrontPageComponent } from './front-page/front-page.component';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    AddGameComponent,
    GameReviewComponent,
    FrontPageComponent
  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
