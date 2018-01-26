import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material';

import { GameRuleModel } from '../models/game.rule.model';

@Component({
  selector: 'ml-rules',
  templateUrl: './rules.component.html',
  styleUrls: ['./rules.component.scss']
})
export class RulesComponent implements OnInit {
  rules: GameRuleModel[];
  
  constructor(public dialogRef: MatDialogRef<RulesComponent>) {
    this.rules = [];
    this.rules.push(
      <GameRuleModel> {
        name: 'Ambush',
        description: 'Ability that is triggered once the enemy enters the city.'
      }
    )
   }

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
