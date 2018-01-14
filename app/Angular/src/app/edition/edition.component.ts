import { Component, OnInit } from '@angular/core';

import { EditionModel } from '../models/edition.model';
import { EditionService } from '../services/edition.service';

@Component({
  selector: 'ml-edition',
  templateUrl: './edition.component.html',
  styleUrls: ['./edition.component.scss']
})
export class EditionComponent implements OnInit {
  editions: EditionModel[] = [];

  constructor(private svc: EditionService) { }

  ngOnInit() {
    this.svc.editions.subscribe(data => {
      this.editions = data;
      this.editions.forEach(edition => edition.checked = false);
    });
  }
}
