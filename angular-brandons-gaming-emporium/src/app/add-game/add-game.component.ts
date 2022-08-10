import { Component } from '@angular/core';

import { Game } from '../game';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.css']
})
export class AddGameComponent {

  tags = ['Multiplayer', 'Looter Shooter',
            'RPG', 'Single Player'];

  model = new Game(1, "Borderlands 2", 5, "Gearbox", "2K", 2012, ["Computer"], this.tags);

  submitted = false;

  onSubmit() { this.submitted = true; }
  
  showFormControls(form: any) {
    return form && form.controls.name &&
    form.controls.name.value; 
  }


}
