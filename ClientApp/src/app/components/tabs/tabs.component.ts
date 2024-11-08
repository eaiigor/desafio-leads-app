import {Component} from '@angular/core';
import {InvitedComponent} from "../invited/invited.component";

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.scss']
})
export class TabsComponent {
  selected = 0;
  tabs = [
    {title: 'Invited'},
    {title: 'Accepted'},
  ];

  select(index: number) {
    this.selected = index;
  }

  isSelected(index: number) {
    return this.selected === index;
  }
}
