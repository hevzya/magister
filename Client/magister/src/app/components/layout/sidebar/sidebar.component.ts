import { Component, OnInit } from '@angular/core';
import { TokenService } from 'src/services/token.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  email: string = '';

 constructor(private tokenService: TokenService) {}

  ngOnInit(): void {

    var decoded = this.tokenService.getTokenPayload();
    this.email = 'Адмін';
  }

}
