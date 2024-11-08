import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AcceptedComponent} from './accepted.component';
import {LeadServiceModule} from "../../services/lead/lead-service.module";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";


@NgModule({
  declarations: [
    AcceptedComponent
  ],
  exports: [
    AcceptedComponent
  ],
  imports: [
    CommonModule,
    LeadServiceModule,
    FontAwesomeModule,
  ]
})
export class AcceptedModule {
}
