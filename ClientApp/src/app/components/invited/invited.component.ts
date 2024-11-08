import {Component} from '@angular/core';
import {LeadService} from "../../services/lead/lead.service";
import {Observable} from "rxjs";
import {Lead} from "../../models/lead";
import {faBriefcase, faLocation, faLocationArrow, faLocationPin} from "@fortawesome/free-solid-svg-icons";
import {LeadStatusEnum} from "../../enums/lead-status.enum";

@Component({
  selector: 'app-invited',
  templateUrl: './invited.component.html',
  styleUrls: ['./invited.component.scss']
})
export class InvitedComponent {
  leads$: Observable<Lead[]>;

  constructor(private leadService: LeadService) {
    this.leads$ = this.leadService.getLeads(LeadStatusEnum.Invited);
  }

  protected readonly faLocation = faLocation;
  protected readonly faLocationArrow = faLocationArrow;
  protected readonly faLocationPin = faLocationPin;
  protected readonly faBriefcase = faBriefcase;

  public acceptLead(lead: Lead) {
    this.leadService.updateLeadStatus(lead, LeadStatusEnum.Accepted).subscribe(() => {
      this.leads$ = this.leadService.getLeads(LeadStatusEnum.Invited);
      alert('Lead accepted successfully!');
    });
  }

  public declineLead(lead: Lead) {
    this.leadService.updateLeadStatus(lead, LeadStatusEnum.Declined).subscribe(() => {
      this.leads$ = this.leadService.getLeads(LeadStatusEnum.Invited);
      alert('Lead declined successfully!');
    });
  }
}
