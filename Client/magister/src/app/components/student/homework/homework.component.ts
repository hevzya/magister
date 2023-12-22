import { Component } from '@angular/core';

export interface Subject {
  name?: string;
  description?: string;
  missingHomeworks: number;
  failedHomeworks: number;
}


@Component({
  selector: 'app-homework',
  templateUrl: './homework.component.html',
  styleUrls: ['./homework.component.scss']
})
export class HomeworkComponent {

  subjects: Subject[] =[
    {
      name: 'Math',
      missingHomeworks: 0,
      failedHomeworks: 0
    },
    {
      name: 'Physics',
      missingHomeworks: 0,
      failedHomeworks: 0
    },
    {
      name: 'Biology',
      missingHomeworks: 3,
      failedHomeworks: 0
    },
    {
      name: 'Chemistry',
      missingHomeworks: 4,
      failedHomeworks: 2
    },
    {
      name: 'History',
      missingHomeworks: 0,
      failedHomeworks: 1
    }, 
  ]


}
