import { Component, OnInit, OnDestroy } from '@angular/core';
import { CourseService } from 'src/app/service/course.service';
import { Course } from 'src/app/domain/course';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit, OnDestroy {

  public courses!: Course[];
  public subCourses!: Subscription;

  constructor(public courseService: CourseService) { }

  ngOnInit(): void {
    this.getAll();
  }

  ngOnDestroy(): void {
    this.subCourses.unsubscribe();
  }

  getAll() {
    this.subCourses = this.courseService.getAll().subscribe(data => {
      this.courses = data;
    });
  } 

}
