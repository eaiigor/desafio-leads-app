import {Component} from '@angular/core';
import {LeadService} from "../../services/lead/lead.service";
import {Observable} from "rxjs";
import {Lead} from "../../models/lead";
import {
  faBriefcase,
  faEnvelope,
  faLocation,
  faLocationArrow,
  faLocationPin,
  faPhone
} from "@fortawesome/free-solid-svg-icons";
import {LeadStatusEnum} from "../../enums/lead-status.enum";

@Component({
  selector: 'app-accepted',
  templateUrl: './accepted.component.html',
  styleUrls: ['./accepted.component.scss']
})
export class AcceptedComponent {
  leads$: Observable<Lead[]>;

  constructor(private leadService: LeadService) {
    this.leads$ = this.leadService.getLeads(LeadStatusEnum.Accepted);
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

  protected readonly faPhone = faPhone;
  protected readonly faEnvelope = faEnvelope;
}
