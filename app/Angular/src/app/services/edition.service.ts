import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { EditionModel } from '../models/edition.model';

@Injectable()
export class EditionService {
  editions: EditionModel[] = [];

  constructor(private http: HttpClient) {
    this.http.get<EditionModel[]>('/api/Edition').subscribe(data => {
      this.editions = data;
    });
  }
}
