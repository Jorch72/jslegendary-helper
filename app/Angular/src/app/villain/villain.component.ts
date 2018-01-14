import { Component, OnInit } from '@angular/core';

import { VillainService } from '../services/villain.service';

@Component({
  selector: 'ml-villain',
  templateUrl: './villain.component.html',
  styleUrls: ['./villain.component.scss']
})
export class VillainComponent implements OnInit {

  constructor(public svc: VillainService) { }

  ngOnInit() {
    this.svc.getVillainDeck();
    console.log(this.svc.villainDeck);
  }

}
