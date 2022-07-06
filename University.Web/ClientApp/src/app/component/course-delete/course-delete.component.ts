import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from '../../domain/course';
import { CourseService } from '../../service/course.service';

@Component({
  selector: 'app-course-delete',
  templateUrl: './course-delete.component.html',
  styleUrls: ['./course-delete.component.css']
})
export class CourseDeleteComponent implements OnInit {
  public id!: number;
  public course!: Course;
  public resultado: any = {
    showMessage: false,
    message: '',
    type: ''
  };

  constructor(public courseService: CourseService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.getOne();
  }

  public getOne() {
    //let paramId = this.activatedRoute.snapshot.paramMap.get("id"); //this.activatedRoute.params['_value'];
    this.id = Number(this.activatedRoute.snapshot.paramMap.get("id"));
    this.courseService.getOne(this.id).subscribe(data => {
      this.course = data;
    });
  }

  public delete() {
    console.log(this.course);

    this.courseService.delete(this.course.CourseID).subscribe(data => {
      this.router.navigate(['/course-list']);
    }, error => {
      console.log(error);
      this.resultado.showMessage = true;
      this.resultado.message = 'An error has ocurred in the procedure';
      this.resultado.type = "danger";
    });
  }

}
