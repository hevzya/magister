import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ADMIN_ROLE } from 'src/app/consts/consts';
import { Claims, TokenService } from 'src/services/token.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  email: string = '';

  claims: Claims = {}

  ADMIN_ROLE = ADMIN_ROLE;

  constructor(private tokenService: TokenService,
    private router: Router) { }


  ngOnInit(): void {
    this.claims = this.tokenService.getClaims();

    this.email = this.claims.name!;
  }



  logout() {
    this.tokenService.removeToken();
    this.router.navigate(['login']);
  }
}
