import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {inject} from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class Student {

  private http = inject(HttpClient);

  public getStudentById(studentId: number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/api/student/${studentId}`);
  }

}
