import { Component } from '@angular/core';
import { StudentCard } from '../student-card/student-card';
import { LessonPlan } from '../lesson-plan/lesson-plan';

@Component({
  selector: 'app-lesson-plan-layout',
  imports: [StudentCard, LessonPlan],
  templateUrl: './lesson-plan-layout.html',
  styleUrl: './lesson-plan-layout.scss',
})
export class LessonPlanLayout {}
