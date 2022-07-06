import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Course } from '../../domain/course';
import { CourseService } from '../../service/course.service';

@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.css']
})
export class CourseEditComponent implements OnInit {
  public id!: number;
  public course!: Course;
  public resultado: any = {
    showMessage: true,
    message: '',
    type: ''
  };

  constructor(public courseService: CourseService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  )
  { }

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

  public edit() {
    console.log(this.course);

    this.courseService.edit(this.course).subscribe(data => {
      this.router.navigate(['/course-list']);
    }, error => {
        console.log(error);
        this.resultado.showMessage = true;
        this.resultado.message = 'An error has ocurred in the procedure';
        this.resultado.type = "danger";
    });
  }

}
