import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { defaultstudent, StudentCardView } from '../../../Models/student';
@Component({
  selector: 'app-student-card',
  imports: [CommonModule],
  templateUrl: './student-card.html',
  styleUrls: ['./student-card.scss'],
  standalone: true,
})
export class StudentCard  {
  @Input() student: StudentCardView = defaultstudent;
}
