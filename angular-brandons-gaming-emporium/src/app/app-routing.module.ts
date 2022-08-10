import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HeroFormComponent } from './hero-form/hero-form.component';
import { GameReviewComponent } from './game-review/game-review.component';

const routes: Routes = [
  { path: '', redirectTo: '/Games', pathMatch: 'full' },
  { path: 'Games', component: HeroFormComponent },
  { path: 'Review', component: GameReviewComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
