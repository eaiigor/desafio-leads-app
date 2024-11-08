import {Person} from "./person";
import {Job} from "./job";
import {LeadStatusEnum} from "../enums/lead-status.enum";

export interface Lead {
  id: number;
  createdAt: string;
  status: LeadStatusEnum;
  person: Person;
  job: Job;
  salaryProposed: number;
}
