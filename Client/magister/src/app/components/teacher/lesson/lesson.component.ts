import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { StudentModel } from '../../admin/admin-panel/admin-panel.component';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent implements OnInit {

  readonly API_URL = 'https://localhost:7211/api/';
  public students: StudentModel[] = [];


  constructor(private http: HttpClient) {

  }

  async ngOnInit(): Promise<void> {
    await this.getStudents();
  }

  private async getStudents() {
    const res = await this.http.get<StudentModel[]>(this.API_URL + 'Students/GetStudents').toPromise();

    if (res) {
      this.students = res;
    }

    console.log(this.students);
  }

}
