import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from 'src/services/token.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  email: string = '';

  constructor(private tokenService: TokenService,
    private router: Router) { }


  ngOnInit(): void {
    var decoded = this.tokenService.getTokenPayload();
    this.email = 'Адмін';
  }



  logout() {
    this.tokenService.removeToken();
    this.router.navigate(['login']);
  }
}
