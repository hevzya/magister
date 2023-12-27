import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { NgbAlertModule, NgbDatepickerModule, NgbModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AdminPanelComponent } from './components/admin/admin-panel/admin-panel.component';
import { ScheduleComponent } from './components/student/schedule/schedule.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { ACCESS_TOKEN } from 'src/services/token.service';
import { HeaderComponent } from './components/layout/header/header.component';
import { SidebarComponent } from './components/layout/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { CommonModule } from '@angular/common';
import { CalendarHeaderComponent } from './components/utils/calendar-header';
import { LessonComponent } from './components/teacher/lesson/lesson.component';
import { HomeworkComponent } from './components/student/homework/homework.component';
import { AdminLessonsComponent } from './components/admin/admin-panel/entities/admin-lessons/admin-lessons.component';
import { AdminStudentsComponent } from './components/admin/admin-panel/entities/admin-students/admin-students.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MyErrorHandler } from './components/utils/error-handler';
import { MarksComponent } from './components/student/marks/marks.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    AdminPanelComponent,
    ScheduleComponent,
    NotFoundComponent,
    HeaderComponent,
    SidebarComponent,
    CalendarHeaderComponent,
    LessonComponent,
    HomeworkComponent,
    AdminLessonsComponent,
    AdminStudentsComponent,
    MarksComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => { return localStorage.getItem(ACCESS_TOKEN) },
      }
    }),
    BrowserAnimationsModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    NgbPaginationModule, NgbAlertModule,
    NgbDatepickerModule,
    NgxDatatableModule.forRoot({
      messages: {
        emptyMessage: 'No data to display', // Message to show when array is presented, but contains no values
        totalMessage: 'total', // Footer total message
        selectedMessage: 'selected' // Footer selected message
      }
    })
  ],
  providers: [
    {provide: ErrorHandler, useClass: MyErrorHandler}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
