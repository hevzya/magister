import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { API_URL } from '../../../../../consts/consts';
import { OdataResult } from '../../../../utils/odataHelpers';

export interface LessonModel {
  cabinet: string,
  description: string,
  lessonStartDate: Date,
  theme: string,
  teacher: {
    name: string,
    surname: string
  },
  group: {
    groupName: string
  },
  subject: {
    name: string
  }
}

@Component({
  selector: 'app-admin-lessons',
  templateUrl: './admin-lessons.component.html',
  styleUrls: ['./admin-lessons.component.scss']
})
export class AdminLessonsComponent implements OnInit {
  
  lessons: LessonModel[] = [];
  
  total: number = 0;
  currentPage: number = 1;
  pageSize: number = 5;


  constructor(private http: HttpClient) { }


  async ngOnInit(): Promise<void> {
    await this.getData();
    
  }

  async refresh() {
    await this.getData();
  }

  private async getData() {
    
    var url = API_URL + 'Lessons?';
    url += `$top=${this.pageSize}`;
    url += `&skip=${this.pageSize*(this.currentPage-1)}`;
    url += `&expand=Teacher`
    url += `&expand=Group`
    url += `&expand=Subject`
    url += `&count=true`;

    var res = await this.http.get<OdataResult>(url).toPromise();
    this.total = res?.['@odata.count']!;
    if (res) {
      this.lessons = res.value;
    } else {
      alert("Сталася помилка");
    }
  }

}
