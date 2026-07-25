import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Student } from '../../../Services/student/student';
import { take } from 'rxjs';

interface StudentCardView {
  name: string;
  age: number;
  level: number;
  photoUrl: string;
}

@Component({
  selector: 'app-student-card',
  imports: [CommonModule],
  templateUrl: './student-card.html',
  styleUrls: ['./student-card.scss'],
  standalone: true,
})
export class StudentCard implements OnInit {
  public student: StudentCardView = {
    name: 'Sara Martinez',
    age: 7,
    level: 2,
    photoUrl:
      'https://images.unsplash.com/photo-1524504388940-b1c1722653e1?auto=format&fit=crop&w=400&q=80',
  };

  constructor(private studentService: Student) {}

  ngOnInit(): void {
    this.subGetStudentById();
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
