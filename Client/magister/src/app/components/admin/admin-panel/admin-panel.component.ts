import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from 'src/services/token.service';

export interface StudentModel {
  name?: string,
  email?: string,
  phoneNumber?: string,
  age?: number,
  gender?: string,
  address?: string
};

export interface CreateUserRequest {
  email: string,
  password: string,
  phoneNumber: string
  name: string
  role: string
}

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  readonly API_URL = 'https://localhost:7211/api/';
  public students: StudentModel[] = [];

  createUserRequest: CreateUserRequest = {
    email: 'nerevit7@gmail.com',
    name: 'VasyanVasyanov', 
    password: Math.random().toString(36).slice(-10),
    phoneNumber: '88005553535',
    role: 'student'
  };

  constructor(
    private http: HttpClient,
    private tokenService: TokenService,
    private router: Router) {
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


  async onCreateUser() {

    const res = await this.http.post(this.API_URL + 'Account/CreateUser', this.createUserRequest, {responseType: 'text'} ).toPromise();

    console.log(res);
    if (res) {
      await this.getStudents();
    }

  }
  
  logout() {
    this.tokenService.removeToken();
    this.router.navigate(['login']);
  }


}
