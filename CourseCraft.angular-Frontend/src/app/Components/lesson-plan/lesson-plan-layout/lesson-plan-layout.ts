import { Component, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { StudentCard } from '../student-card/student-card';
import { LessonPlan } from '../lesson-plan/lesson-plan';
import { Student } from '../../../Services/student/student';
import { BehaviorSubject, Subject, take, tap } from 'rxjs';
import {  defaultstudent, 
          defaultStudentAIRequest, 
          defaultStudentResponse, 
          StudentAIRequest, 
          StudentCardView, 
          StudentResponse, 
          StudentResponseToAIRequest} from '../../../Models/student';
import { LessonPlanService } from '../../../Services/Lesson-plan/lesson-plan';
import { defaultLessons, LessonGUI, LessonI } from '../../../Models/lesson';
@Component({
  selector: 'app-lesson-plan-layout',
  imports: [AsyncPipe, StudentCard, LessonPlan],
  templateUrl: './lesson-plan-layout.html',
  styleUrl: './lesson-plan-layout.scss',
})
export class LessonPlanLayout implements OnInit {

  public studentCard: StudentCardView = defaultstudent;
  public $lessonGUILIst: Subject<LessonGUI[]>;
  public studentResponse: StudentResponse = defaultStudentResponse;
  public studentAIRequest: StudentAIRequest = defaultStudentAIRequest;
  public defaultLessons: LessonGUI[] = defaultLessons;

  constructor(
    private studentService: Student,
    private LessonPlanService: LessonPlanService
  ) {
    this.$lessonGUILIst = new Subject<LessonGUI[]>();
  }

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
      .pipe(
        take(1)
      )
        .subscribe(
          (lessonResp: LessonI[]) => {

          this.$lessonGUILIst.next(
          [
            {
              lesson: lessonResp[0],
              isOpen: false
            }
          ]);
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
