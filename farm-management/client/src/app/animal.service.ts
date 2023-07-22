import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Animal } from './animal.model';
import { API_BASE_URL } from './constants';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AnimalService {
  constructor(private httpClient: HttpClient) {}

  get() {
    return this.httpClient.get<Animal[]>(API_BASE_URL + 'animal');
  }

  create(model: Animal) {
    return this.httpClient.post<Animal>(API_BASE_URL + 'animal', model);
  }
  delete(id: number) {
    return this.httpClient.delete<Animal[]>(API_BASE_URL + 'animal/' + id);
  }
}
