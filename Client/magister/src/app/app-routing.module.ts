import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AdminPanelComponent } from './components/admin/admin-panel/admin-panel.component';
import { AuthGuard } from 'src/services/auth.guard';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ScheduleComponent } from './components/student/schedule/schedule.component';
import { LessonComponent } from './components/teacher/lesson/lesson.component';
import { HomeworkComponent } from './components/student/homework/homework.component';
import { AdminLessonsComponent } from './components/admin/admin-panel/entities/admin-lessons/admin-lessons.component';
import { AdminStudentsComponent } from './components/admin/admin-panel/entities/admin-students/admin-students.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'admin', component: AdminPanelComponent, 
    canActivate: [AuthGuard],
    children: [
    {
      path: 'lessons', component: AdminLessonsComponent
    },
    {
      path: 'students', component: AdminStudentsComponent
    },
  ]
  },
  { path: 'schedule', component: ScheduleComponent, canActivate: [AuthGuard] },
  { path: 'lesson', component: LessonComponent, canActivate: [AuthGuard] },
  { path: 'homework', component: HomeworkComponent, canActivate: [AuthGuard] },
  { path: '**', component: NotFoundComponent }
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
