import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddGameComponent } from './add-game/add-game.component';
import { GameReviewComponent } from './game-review/game-review.component';

const routes: Routes = [
  { path: '', redirectTo: '/Games', pathMatch: 'full' },
  { path: 'Games', component: AddGameComponent },
  { path: 'Review', component: GameReviewComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
