import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Lesson } from '../lesson/lesson';

interface LessonItem {
  id: number;
  title: string;
  content: string;
  isOpen: boolean;
}

@Component({
  selector: 'app-lesson-plan',
  imports: [CommonModule, Lesson],
  templateUrl: './lesson-plan.html',
  styleUrl: './lesson-plan.scss',
})
export class LessonPlan {
  lessons: LessonItem[] = [
    {
      id: 1,
      title: 'Section 1',
      content: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris.`,
      isOpen: false,
    },
    {
      id: 2,
      title: 'Section 2',
      content: `Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore 
        eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa 
        qui officia deserunt mollit anim id est laborum.`,
      isOpen: false,
    },
    {
      id: 3,
      title: 'Section 3',
      content: `Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque 
        laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto 
        beatae vitae dicta sunt explicabo.`,
      isOpen: false,
    },
  ];

  toggleAccordion(index: number): void {
    this.lessons[index].isOpen = !this.lessons[index].isOpen;
  }
}
