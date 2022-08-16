import { Component, OnInit } from '@angular/core';
import { CoursesService } from '../Services/courses.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
  
  constructor(private coursesService: CoursesService) { }

  courses = [];

  ngOnInit(): void {
    this.courses = this.coursesService.courses;
  }

}
