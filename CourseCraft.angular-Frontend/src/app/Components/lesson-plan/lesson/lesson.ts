import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-lesson',
  imports: [],
  templateUrl: './lesson.html',
  styleUrl: './lesson.scss',
})
export class Lesson {
  @Input() content: string = 'No content provided';
}
