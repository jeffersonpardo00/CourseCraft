import { Component, OnInit } from '@angular/core';
import { StudentCard } from '../student-card/student-card';
import { LessonPlan } from '../lesson-plan/lesson-plan';
import { Student } from '../../../Services/student/student';
import { take } from 'rxjs';
import { defaultstudent, StudentCardView } from '../../../Models/student';
import { LessonPlanService } from '../../../Services/Lesson-plan/lesson-plan';
import { defaultLessons, LessonI } from '../../../Models/lesson';
@Component({
  selector: 'app-lesson-plan-layout',
  imports: [StudentCard, LessonPlan],
  templateUrl: './lesson-plan-layout.html',
  styleUrl: './lesson-plan-layout.scss',
})
export class LessonPlanLayout implements OnInit {

  public student: StudentCardView = defaultstudent;
  public lessons: LessonI[] = defaultLessons;

  constructor(
    private studentService: Student,
    private LessonPlanService: LessonPlanService
  ) {}

  ngOnInit(): void {
    this.subGetStudentById();
  }

  private subGetAllLessons():void {

    this.LessonPlanService
    .getAllLessons()
     .pipe(take(1))
      .subscribe((resp: any) => {
        //chage
        
      });
  }

  private subGetStudentById(): void {
    this.studentService
      .getStudentById(1)
      .pipe(take(1))
      .subscribe((resp: any) => {
        if (!resp) {
          return;
        }

        const fullName = [
          resp.firstName,
          resp.middleName,
          resp.lastName,
          resp.lastName2,
        ]
          .filter(Boolean)
          .join(' ');

        this.student = {
          name: fullName || this.student.name,
          age: this.calculateAge(resp.birthDate) || this.student.age,
          level: resp.learningLevel ?? this.student.level,
          photoUrl: resp.photoUrl ?? this.student.photoUrl,
        };
      });
  }

    private calculateAge(birthDate: string | Date): number {
    const date = typeof birthDate === 'string' ? new Date(birthDate) : birthDate;
    const diff = Date.now() - date.getTime();
    const age = new Date(diff).getUTCFullYear() - 1970;
    return age > 0 ? age : this.student.age;
  }


}
