import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { HeroDeckPostModel } from '../models/hero.deck.post.model';
import { HeroModel } from '../models/hero.model';
import { RuleModel } from '../models/rule.model';

import { PlayerService } from './player.service';
import { VillainService } from './villain.service';

@Injectable()
export class HeroService {
    heroDeck: HeroModel[];

    constructor(private http: HttpClient,
        private playerSvc: PlayerService,
        private villainSvc: VillainService) { }

    getHeroDeck() {
        this.heroDeck = null;
        let rules: RuleModel[] = [];

        if(this.villainSvc.villainDeck !== null) {
            if(this.villainSvc.villainDeck.scheme.rules !== null) {
                this.villainSvc.villainDeck.scheme.rules.forEach(rule => {
                    rules.push(rule);
                })
            }
            if(this.villainSvc.villainDeck.masterminds != null) {
                this.villainSvc.villainDeck.masterminds.forEach(mastermind => {
                    if(mastermind.rules !== null) {
                        mastermind.rules.forEach(rule => {
                            rules.push(rule);
                        })
                    }
                })
            }
            if(this.villainSvc.villainDeck.villains != null) {
                this.villainSvc.villainDeck.villains.forEach(villain => {
                    if(villain.rules !== null) {
                        villain.rules.forEach(rule => {
                            rules.push(rule);
                        })
                    }
                })
            }
            if(this.villainSvc.villainDeck.henchmen != null) {
                this.villainSvc.villainDeck.henchmen.forEach(henchman => {
                    if(henchman.rules !== null) {
                        henchman.rules.forEach(rule => {
                            rules.push(rule);
                        })
                    }
                })
            }

            let heroDeckPost = <HeroDeckPostModel>{
                filter: this.villainSvc.villainDeck.filter,
                rules: rules
            };

            this.http.post<HeroModel[]>('/api/HeroDeck', heroDeckPost)
                .subscribe(data => {
                    this.heroDeck = data;
                });
        }
    }
}
