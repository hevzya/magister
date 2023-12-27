import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectionStrategy, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalendarEvent, CalendarEventAction, CalendarEventTimesChangedEvent, CalendarView } from 'angular-calendar';
import { EventColor } from 'calendar-utils';
import { addDays, addHours, endOfDay, endOfMonth, isSameDay, isSameMonth, parseISO, startOfDay, subDays } from 'date-fns';
import { Subject } from 'rxjs';
import { API_URL, STUDENT_ROLE } from 'src/app/consts/consts';
import { OdataResult } from '../../utils/odataHelpers';
import { Router } from '@angular/router';
import { Claims, TokenService } from 'src/services/token.service';


export const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
};

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  constructor(private http: HttpClient, private router: Router, private tokenService: TokenService) {}

  claims: Claims = {};

  async ngOnInit(): Promise<void> {
    
    this.claims = this.tokenService.getClaims();

    const res = await this.http.get<OdataResult>(API_URL + 'Lessons').toPromise();
    const datePipe = new DatePipe('en-US');
    if (res) {
    
      
      res.value.forEach(lesson => {
        // console.log(parseISO(lesson.lessonStartDate!));
        this.events.push({
          title: lesson.theme! + ' [' + datePipe.transform(parseISO(lesson.lessonStartDate!),'HH:mm') + ']',
          color: colors.blue,
          start: parseISO(lesson.lessonStartDate!),
          id: lesson.id
        });

        this.refresh.next();

      });
    }

  }

  mapDate(date: Date) {
    return date.getHours() + ':' + date.getMinutes();
  }

  view: CalendarView = CalendarView.Month;

  viewDate: Date = new Date();

  events: CalendarEvent[] = [];

  activeDayIsOpen: boolean = true;

  refresh = new Subject<void>();

  eventClicked({ event }: { event: CalendarEvent }): void {

    if(this.claims.role === STUDENT_ROLE) {
      return;
    }

    this.router.navigateByUrl('lesson/'+event.id)

    console.log('Event clicked', event);
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }

  handleEvent(action: string, event: CalendarEvent): void {
    console.log("EVENT");
  }

}
