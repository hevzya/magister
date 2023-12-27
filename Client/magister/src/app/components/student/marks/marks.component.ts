import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CalendarEvent, CalendarView } from 'angular-calendar';
import { Subject } from 'rxjs';
import { API_URL } from 'src/app/consts/consts';
import { TokenService } from 'src/services/token.service';
import { addDays, addHours, endOfDay, endOfMonth, isSameDay, isSameMonth, parseISO, startOfDay, subDays } from 'date-fns';
import { DatePipe } from '@angular/common';


export interface MarkModel {
  mark: number,
  date: Date
}

export interface SubjectMarkModel {
  name?: string,
  examMarks?: MarkModel[]
  lessonMarks?: MarkModel[]
}


@Component({
  selector: 'app-marks',
  templateUrl: './marks.component.html',
  styleUrls: ['./marks.component.scss']
})
export class MarksComponent implements OnInit {


  token?: any;
  userId?: string;

  subjects?: SubjectMarkModel[];
  selectedSubject?: SubjectMarkModel;

  datePipe = new DatePipe('en-US');

  constructor(private http: HttpClient, private tokenService: TokenService) {}

  selectSubject(event?: any) {
    if (event.target.value === 'Всі') {
      this.selectedSubject = undefined;
    }
    else {
      this.selectedSubject = this.subjects?.find(x => x.name === event.target.value);
    }
     
    this.initCalendar();
  }

  public initCalendar() {
    this.events = [];
    if (!this.selectedSubject) {
      this.events = [];

      this.subjects?.forEach(subject => {
        subject!.lessonMarks!.forEach(mark => {

          this.events.push({
            color: {
              primary: '#1e90ff',
              secondary: '#D1E8FF',
            },
  
            title: subject!.name! + ' [' + this.datePipe.transform(parseISO(new Date (mark.date!).toISOString()),'HH:mm') + ']',
            start: parseISO(new Date (mark.date!).toISOString()),
            meta: {
              mark: mark.mark
            }
          });
  
        });
  
        subject!.examMarks!.forEach(mark => {
  
          this.events.push({
            color: {
              primary: '#e3bc08',
              secondary: '#FDF1BA',
            },
            title: subject!.name! + ' [' + this.datePipe.transform(parseISO(new Date (mark.date!).toISOString()),'HH:mm') + ']',
            start: parseISO(new Date (mark.date!).toISOString()),
            meta: {
              mark: mark.mark
            }
          });
  
        });
      })

    } 
    else {
      

      this.selectedSubject!.lessonMarks!.forEach(mark => {

        this.events.push({
          color: {
            primary: '#1e90ff',
            secondary: '#D1E8FF',
          },

          title: this.selectedSubject!.name! + ' [' + this.datePipe.transform(parseISO(new Date (mark.date!).toISOString()),'HH:mm') + ']',
          start: parseISO(new Date (mark.date!).toISOString()),
          meta: {
            mark: mark.mark
          }
        });

      });

      this.selectedSubject!.examMarks!.forEach(mark => {

        this.events.push({
          color: {
            primary: '#e3bc08',
            secondary: '#FDF1BA',
          },
          title: this.selectedSubject!.name! + ' [' + this.datePipe.transform(parseISO(new Date (mark.date!).toISOString()),'HH:mm') + ']',
          start: parseISO(new Date (mark.date!).toISOString()),
          meta: {
            mark: mark.mark
          }
        });

      });
      
    }

    this.refresh.next();
  }

  async ngOnInit(): Promise<void> {
    this.token = this.tokenService.getTokenPayload()

    this.userId = this.token['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];

    console.log(this.token );

    var res = await this.http.get<SubjectMarkModel[]>(API_URL + 'api/Subjects?userId=' + this.userId).toPromise()

    if(res) {
      this.subjects = res;

      this.initCalendar();
    }

    console.log(res);
  }


  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();
  events: CalendarEvent[] = [];
  refresh = new Subject<void>();

}
