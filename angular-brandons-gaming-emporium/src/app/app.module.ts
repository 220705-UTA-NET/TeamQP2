import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AddGameComponent } from './add-game/add-game.component';
import { GameReviewComponent } from './game-review/game-review.component';
import { FrontPageComponent } from './front-page/front-page.component';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule
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
