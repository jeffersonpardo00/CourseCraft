import { Component, Input } from '@angular/core';
import { LessonContent } from '../../../Models/lesson';

@Component({
  selector: 'app-lesson',
  imports: [],
  templateUrl: './lesson.html',
  styleUrl: './lesson.scss',
})
export class Lesson {
  @Input() content: LessonContent = {
    explanation: 'No content provided',
    strategies:'No content provided'
  };
}
