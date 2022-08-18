import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FreebiesService } from 'src/app/Services/freebies.service';

@Component({
  selector: 'app-freebie',
  templateUrl: './freebie.component.html',
  styleUrls: ['./freebie.component.css']
})
export class FreebieComponent implements OnInit {

  constructor(private service: FreebiesService, private route: ActivatedRoute) { }

  freebie;
  freebieId: number;

  ngOnInit(): void {
    this.freebieId = this.route.snapshot.params['id'];
    //this.freebieId = this.route.snapshot.params['name'];
    this.freebie = this.service.freebies.find(x => x.id == this.freebieId);
  }

  

}
