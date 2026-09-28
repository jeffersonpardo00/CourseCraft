import { Component, OnInit } from '@angular/core';
import { StudentCard } from '../student-card/student-card';
import { LessonPlan } from '../lesson-plan/lesson-plan';
import { Student } from '../../../Services/student/student';
import { take } from 'rxjs';
import {  defaultstudent, 
          defaultStudentResponse, 
          StudentCardView, 
          StudentResponse } from '../../../Models/student';
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

  constructor(
    private studentService: Student,
    private LessonPlanService: LessonPlanService
  ) {}

  ngOnInit(): void {
    this.subGetStudentById();
    this.subGetAllLessons();
    this.subCreateLessonsPlan();
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

  private subCreateLessonsPlan():void {
    this.LessonPlanService
    .CreateLessonsPlan()
     .pipe(take(1))
      .subscribe((resp: any) => {
        //chage
        console.log(resp);
        
      });
  }


  private subGetStudentById(): void {
    this.studentService
      .getStudentById(1)
      .pipe(take(1))
      .subscribe((resp: StudentResponse) => {
        if (!resp) {
          return;
        }

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
