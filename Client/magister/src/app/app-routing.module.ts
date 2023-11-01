import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AdminPanelComponent } from './components/admin/admin-panel/admin-panel.component';
import { AuthGuard } from 'src/services/auth.guard';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ScheduleComponent } from './components/student/schedule/schedule.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'admin', component: AdminPanelComponent, canActivate: [ AuthGuard ] },
  { path: 'schedule', component: ScheduleComponent, canActivate: [ AuthGuard ] },
  { path: '**', component: NotFoundComponent }
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
