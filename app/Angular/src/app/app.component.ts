import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';

import { RulesComponent } from './rules/rules.component';

@Component({
  selector: 'ml-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ml';

  constructor(public dialog: MatDialog) {}

  openDialog(): void {
    let dialogRef = this.dialog.open(RulesComponent, {
      // width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
