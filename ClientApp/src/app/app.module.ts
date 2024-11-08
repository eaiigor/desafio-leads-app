import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './components/nav-menu/nav-menu.component';
import {HomeComponent} from './pages/home/home.component';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import {NavMenuModule} from "./components/nav-menu/nav-menu.module";
import {HomeModule} from "./pages/home/home.module";

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    FormsModule,
    RouterModule.forRoot([
      {path: '', loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule)},
    ]),
    FontAwesomeModule,
    NavMenuModule,
    HomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
