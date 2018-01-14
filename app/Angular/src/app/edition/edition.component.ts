import { Component } from '@angular/core';

import { EditionModel } from '../models/edition.model';
import { EditionService } from '../services/edition.service';

@Component({
  selector: 'ml-edition',
  templateUrl: './edition.component.html',
  styleUrls: ['./edition.component.scss']
})
export class EditionComponent  {

  constructor(public svc: EditionService) { }
}
