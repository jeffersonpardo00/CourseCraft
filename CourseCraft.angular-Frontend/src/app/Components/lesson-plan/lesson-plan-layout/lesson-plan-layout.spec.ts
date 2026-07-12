import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonPlanLayout } from './lesson-plan-layout';

describe('LessonPlanLayout', () => {
  let component: LessonPlanLayout;
  let fixture: ComponentFixture<LessonPlanLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LessonPlanLayout],
    }).compileComponents();

    fixture = TestBed.createComponent(LessonPlanLayout);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
