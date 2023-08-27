import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'magister';

  a: string = '';
  b: string = '';

  result = 0;

  add() {
    this.result = Number.parseInt(this.a) + Number.parseInt(this.b);
    console.log(this.result);
  }

}
