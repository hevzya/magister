import { Component, OnInit } from '@angular/core';
import { STUDENT_ROLE } from 'src/app/consts/consts';
import { TokenService } from 'src/services/token.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  email: string = '';
  role: string = '';

  STUDENT_ROLE = STUDENT_ROLE;

 constructor(private tokenService: TokenService) {}

  ngOnInit(): void {

    var decoded = this.tokenService.getTokenPayload();
    console.log(decoded);

    this.email = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    this.role = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    console.log(this.role);
  }

}
