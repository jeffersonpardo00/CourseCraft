import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { StudentAIRequest } from '../../Models/student';

@Injectable({
  providedIn: 'root',
})
export class LessonPlanService {
  private http = inject(HttpClient);

  public getAllLessons(): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/api/lesson`);
  }

  public CreateLessonsPlan(studentAIRequest: StudentAIRequest): Observable<any> {
    return this.http.post<any>(
      `${environment.apiUrl}/api/lesson/create`, studentAIRequest);
  }

}
