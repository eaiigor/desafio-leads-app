import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from "./home.component";
import {TabsModule} from "../../components/tabs/tabs.module";
import {RouterModule} from "@angular/router";


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    TabsModule,
    RouterModule.forChild([{
      path: '',
      component: HomeComponent
    }])
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule {
}
