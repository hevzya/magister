import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode'
import { TokenService } from 'src/services/token.service';

export interface LoginResponce {
  accessToken: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  readonly API_URL = 'https://localhost:7211/api/';

  public email = 'admin@gmail.com';
  public password = 'Qwe123!!';
  public rememberMe = false;

  constructor(
    private http: HttpClient,
    private router: Router,
    private tokenService: TokenService) {

  }

  async onLogin() {
    const url = this.API_URL + "Account/Login";
    const body = {
      email: this.email,
      password: this.password
    };

    const result = await this.http.post<LoginResponce>(url, body).toPromise();

    if (result) {
      this.tokenService.setToken(result.accessToken);

      const decodedToken = this.tokenService.getTokenPayload();
      const role: string = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      console.log(decodedToken);
      console.log(role);
      console.log(role == 'admin');
      if (role == 'admin') {
        this.router.navigateByUrl('/admin');
      }
    }
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch (Error) {
      return null;
    }
  }

}
