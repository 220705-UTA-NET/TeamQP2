import { Component, OnInit } from '@angular/core';
import { FreebiesService } from '../Services/freebies.service';

@Component({
  selector: 'app-freebies',
  templateUrl: './freebies.component.html',
  styleUrls: ['./freebies.component.css']
})
export class FreebiesComponent implements OnInit {

  constructor(private freebiesService: FreebiesService) { }

  freebies = [];

  ngOnInit(): void {
    this.freebies = this.freebiesService.freebies;
  }
}
