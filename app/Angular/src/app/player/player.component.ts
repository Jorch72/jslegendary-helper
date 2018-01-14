import { Component } from '@angular/core';

import { PlayerService } from '../services/player.service';

@Component({
  selector: 'ml-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent {
  totalPlayers: number[];

  constructor(public svc: PlayerService) {
    this.totalPlayers = [ 2, 3, 4, 5, 6 ];
  }
}
