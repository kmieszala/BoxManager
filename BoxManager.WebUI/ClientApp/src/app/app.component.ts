import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TestService } from './modules/test.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  constructor(private _translate: TranslateService
    , private _tset: TestService
  ) {
    _translate.setDefaultLang('pl');
  }

  elo() {
    this._tset.test().subscribe(res => {
      console.log(res);
    });
  }
}
