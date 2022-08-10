
import { Component} from '@angular/core';
import { Review } from '../review';


@Component({
  selector: 'app-game-review',
  templateUrl: './game-review.component.html',
  styleUrls: ['./game-review.component.css']
})
export class GameReviewComponent{

  today = new Date();

  model = new Review(1, "Game kinda sucks ong", 1, "LeBrando25", "Rocket League", (this.today.getMonth() + 1) + '-' + this.today.getDate() + '-' +this.today.getFullYear() );

  submitted = false;

  onSubmit() { this.submitted = true; }
  
  showFormControls(form: any) {
    return form && form.controls.name &&
      form.controls.name.value;
  }
}
