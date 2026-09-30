import { Component, OnInit } from '@angular/core';
import { StudentCard } from '../student-card/student-card';
import { LessonPlan } from '../lesson-plan/lesson-plan';
import { Student } from '../../../Services/student/student';
import { take, tap } from 'rxjs';
import {  defaultstudent, 
          defaultStudentAIRequest, 
          defaultStudentResponse, 
          StudentAIRequest, 
          StudentCardView, 
          StudentResponse, 
          StudentResponseToAIRequest} from '../../../Models/student';
import { LessonPlanService } from '../../../Services/Lesson-plan/lesson-plan';
import { defaultLessons, LessonI } from '../../../Models/lesson';
@Component({
  selector: 'app-lesson-plan-layout',
  imports: [StudentCard, LessonPlan],
  templateUrl: './lesson-plan-layout.html',
  styleUrl: './lesson-plan-layout.scss',
})
export class LessonPlanLayout implements OnInit {

  public studentCard: StudentCardView = defaultstudent;
  public lessons: LessonI[] = defaultLessons;
  public studentResponse: StudentResponse = defaultStudentResponse;
  public studentAIRequest: StudentAIRequest = defaultStudentAIRequest;

  constructor(
    private studentService: Student,
    private LessonPlanService: LessonPlanService
  ) {}

  ngOnInit(): void {
    this.subGetStudentById();
    this.subGetAllLessons();
  }

  private subGetAllLessons():void {
    this.LessonPlanService
    .getAllLessons()
     .pipe(take(1))
      .subscribe((resp: any) => {
        //chage
        console.log(resp);
        
      });
  }

  public subCreateLessonsPlan(studentAIReq: StudentAIRequest): void {
    if(studentAIReq != defaultStudentAIRequest)
    {
      this.LessonPlanService
      .CreateLessonsPlan(studentAIReq)
      .pipe(take(1))
        .subscribe((resp: any) => {
          //chage
          console.log(resp);
        });
    }
  }


  private subGetStudentById(): void {
    this.studentService
      .getStudentById(1)
      .pipe(
        take(1),
        tap((resp: StudentResponse) => {

        })
      )
      .subscribe((resp: StudentResponse) => {
        if (!resp) {
          return;
        }

        this.studentAIRequest = StudentResponseToAIRequest(resp);

        const fullName = [
          resp.FirstName,
          resp.MiddleName,
          resp.LastName,
          resp.LastName2,
        ]
          .filter(Boolean)
          .join(' ');

        this.studentCard = {
          name: fullName || this.studentCard.name,
          age: this.calculateAge(resp.BirthDate) || this.studentCard.age,
          level: resp.LearningLevel ?? this.studentCard.level,
          photoUrl: this.studentCard.photoUrl,
        };
      });
  }

  

    private calculateAge(birthDate: string | Date): number {
    const date = typeof birthDate === 'string' ? new Date(birthDate) : birthDate;
    const diff = Date.now() - date.getTime();
    const age = new Date(diff).getUTCFullYear() - 1970;
    return age > 0 ? age : this.studentCard.age;
  }


}
