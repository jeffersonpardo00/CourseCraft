import { TestBed } from '@angular/core/testing';

import { LessonPlan } from './lesson-plan';

describe('LessonPlan', () => {
  let service: LessonPlan;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LessonPlan);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
