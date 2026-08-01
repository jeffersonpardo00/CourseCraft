import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Lesson } from '../lesson/lesson';
import { defaultLessons, LessonI } from '../../../Models/lesson';

@Component({
  selector: 'app-lesson-plan',
  imports: [CommonModule, Lesson],
  templateUrl: './lesson-plan.html',
  styleUrl: './lesson-plan.scss',
})

export class LessonPlan {
  @Input() lessons: LessonI[] = defaultLessons;

  public toggleAccordion(index: number): void {
    this.lessons[index].isOpen = !this.lessons[index].isOpen;
  }
}
