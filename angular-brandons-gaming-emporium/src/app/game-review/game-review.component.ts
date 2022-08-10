import { Component } from '@angular/core';

import { Hero } from '../hero';

@Component({
  selector: 'app-game-review',
  templateUrl: './game-review.component.html',
  styleUrls: ['./game-review.component.css']
})
export class GameReviewComponent {

  tags = ['Multiplayer', 'Looter Shooter',
            'RPG', 'Single Player'];

  model = new Hero(1, "Borderlands 2", 5, "Gearbox", "2K", 2012, ["Computer"], this.tags);

  submitted = false;

  onSubmit() { this.submitted = true; }

  //////// NOT SHOWN IN DOCS ////////

  // Reveal in html:
  //   Name via form.controls = {{showFormControls(heroForm)}}
  showFormControls(form: any) {
    return form && form.controls.name &&
    form.controls.name.value; // Dr. IQ
  }

  /////////////////////////////

}
