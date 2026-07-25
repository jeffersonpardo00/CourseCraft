import { Routes } from '@angular/router';

export const routes: Routes = [
     {
        path: '',
        redirectTo: 'main',
        pathMatch: 'full'
    },
    {
        path: 'lesson-plan',
        loadComponent: () => import('./Components/lesson-plan/lesson-plan-layout/lesson-plan-layout').then(m => m.LessonPlanLayout)
    },
];
