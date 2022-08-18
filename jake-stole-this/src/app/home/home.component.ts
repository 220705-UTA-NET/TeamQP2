import { Component, OnInit } from '@angular/core';
import { FreebiesService } from '../Services/freebies.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private freebiesService: FreebiesService) { }

  freebies = [];

  ngOnInit(): void {
    this.freebies = this.freebiesService.freebies;
  }
  number = Math.floor(Math.random() * 4) + 1;
}
