import { Component } from '@angular/core';
import { AnimalService } from './animal.service';
import { Animal } from './animal.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  onDelete(item: Animal) {
    this.data = this.data?.filter((x) => x.id !== item.id);
  }
  data: Animal[] | undefined = undefined;
  error: any;
  constructor(animalService: AnimalService) {
    animalService.get().subscribe({
      next: (response) => (this.data = response),
      error: (error) => (this.error = error),
    });
  }
}
