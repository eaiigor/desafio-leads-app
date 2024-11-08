import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabsComponent } from './tabs.component';
import {InvitedModule} from "../invited/invited.module";
import {AcceptedModule} from "../accepted/accepted.module";



@NgModule({
  declarations: [
    TabsComponent
  ],
  exports: [
    TabsComponent
  ],
  imports: [
    CommonModule,
    InvitedModule,
    AcceptedModule
  ]
})
export class TabsModule { }
