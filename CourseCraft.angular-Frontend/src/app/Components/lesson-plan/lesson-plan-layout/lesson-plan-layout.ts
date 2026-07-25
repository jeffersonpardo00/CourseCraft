import { Component } from '@angular/core';
import { StudentCard } from '../student-card/student-card';

@Component({
  selector: 'app-lesson-plan-layout',
  imports: [StudentCard],
  templateUrl: './lesson-plan-layout.html',
  styleUrl: './lesson-plan-layout.scss',
})
export class LessonPlanLayout {}
