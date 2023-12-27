import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { OdataResult } from 'src/app/components/utils/odataHelpers';
import { API_URL } from 'src/app/consts/consts';

export interface StudentModel {
  id: string,
  phoneNumber: string,
  dateOfBirth: Date,
  surname: string,
  name: string,
  address: string,
  group: {
    groupName: string
  },
  user: {
    age: number,
    gender: string,
    address: string
  }
}

@Component({
  selector: 'app-admin-students',
  templateUrl: './admin-students.component.html',
  styleUrls: ['./admin-students.component.scss']
})
export class AdminStudentsComponent {


  data: StudentModel[] = [];
  
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
    
    var url = API_URL + 'Students?';
    url += `$top=${this.pageSize}`;
    url += `&skip=${this.pageSize*(this.currentPage-1)}`;
    url += `&expand=User`
    url += `&expand=Group`
    url += `&count=true`;

    var res = await this.http.get<OdataResult>(url).toPromise();
    this.total = res?.['@odata.count']!;
    if (res) {
      this.data = res.value;
    } else {
      alert("Сталася помилка");
    }
  }

  async remove(id: string) {
    var url = API_URL + 'api/delete/DeleteStudent?studentId=' + id;
    var res = await this.http.delete(url).toPromise();
    alert("student was deleted");
    await this.getData();
  }


}
