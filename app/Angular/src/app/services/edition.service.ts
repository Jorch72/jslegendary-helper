import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { EditionModel } from '../models/edition.model';

@Injectable()
export class EditionService {
  editions: EditionModel[] = null;

  constructor(private http: HttpClient) {
    this.http.get<EditionModel[]>('/api/Edition').subscribe(data => {
      this.editions = data;
    });
  }

  clearAll() {
    this.editions.forEach(edition => {
      edition.checked = false;
    });
  }

  selectAll() {
    this.editions.forEach(edition => {
      edition.checked = true;
    });
  }
}
