import {NgModule, OnInit} from "@angular/core";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {LeadService} from "./lead.service";
import {Lead} from "../../models/lead";
import {Observable} from "rxjs";

@NgModule({
  providers: [
    LeadService
  ],
  imports: [
    HttpClientModule,
  ]
})
export class LeadServiceModule {
}
