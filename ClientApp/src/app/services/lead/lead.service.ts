import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Lead} from "../../models/lead";
import {LeadStatusEnum} from "../../enums/lead-status.enum";

@Injectable({
  providedIn: 'root'
})
export class LeadService {
  constructor(@Inject('BASE_URL') private baseUrl: string, private httpClient: HttpClient) {
  }

  public getLeads(status: LeadStatusEnum): Observable<Lead[]> {
    return this.httpClient.get<Lead[]>(this.baseUrl + 'api/lead', {
      params: {
        status: status.toString()
      }
    });
  }

  public updateLeadStatus(lead: Lead, status: LeadStatusEnum): Observable<Lead> {
    return this.httpClient.put<Lead>(this.baseUrl + 'api/lead/' + lead.id, {
      ...lead,
      status: status
    });
  }
}
