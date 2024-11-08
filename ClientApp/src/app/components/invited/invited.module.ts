import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {InvitedComponent} from './invited.component';
import {LeadServiceModule} from "../../services/lead/lead-service.module";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";


@NgModule({
  declarations: [
    InvitedComponent
  ],
  exports: [
    InvitedComponent
  ],
  imports: [
    CommonModule,
    LeadServiceModule,
    FontAwesomeModule,
  ]
})
export class InvitedModule {
}
