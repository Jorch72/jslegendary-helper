import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { UserFilterModel } from '../models/user.filter.model';
import { VillainDeckModel } from '../models/villain.deck.model';

import { PlayerService } from './player.service';
import { EditionService } from './edition.service';

@Injectable()
export class VillainService {
    villainDeck: VillainDeckModel;

    constructor(private http: HttpClient,
        private playerSvc: PlayerService,
        private editionSvc: EditionService) { }

    getVillainDeck() {
        this.villainDeck = null;

        let editions: string[] = [];

        if(this.editionSvc.editions !== null) {
            this.editionSvc.editions.forEach(edition => {
                if (edition.checked) 
                    editions.push(edition.name);
            });

            let userFilter = <UserFilterModel>{
                players: this.playerSvc.players,
                editions: editions
            };

            this.http.post<VillainDeckModel>('/api/VillainDeck', userFilter)
                .subscribe(data => {
                    this.villainDeck = data;
                });
        }
    }
}
