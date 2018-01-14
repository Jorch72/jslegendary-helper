import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { EditionModel } from '../models/edition.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class EditionService {
  editions: Observable<EditionModel[]>;

  constructor(private http: HttpClient) {
    this.editions = this.http.get<EditionModel[]>('/api/Edition');
  }
}
