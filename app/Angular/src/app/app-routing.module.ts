import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlayerComponent } from './player/player.component';
import { EditionComponent } from './edition/edition.component';
import { VillainComponent } from './villain/villain.component';

const routes: Routes = [
  { path: 'player', component: PlayerComponent },
  { path: 'edition', component: EditionComponent },
  { path: 'villain', component: VillainComponent },
  { path: '', redirectTo: '/player', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
