import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { FilterModel } from '../models/filter.model';
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
        let editions: string[] = [];
        this.editionSvc.editions.forEach(edition => {
            editions.push(edition.name);
        });

        let filter = <FilterModel>{
            players: this.playerSvc.players,
            editions: editions
        };

        this.http.post<VillainDeckModel>('/api/VillainDeck', filter)
            .subscribe(data => {
                this.villainDeck = data;
                console.log('DATA');
                console.log(data);
            });
    }
}
