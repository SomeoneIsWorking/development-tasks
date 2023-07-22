import { Component, EventEmitter, Output } from '@angular/core';
import { AnimalService } from '../animal.service';
import { Animal } from '../animal.model';

@Component({
  selector: 'app-animal-form',
  templateUrl: './animal-form.component.html',
  styleUrls: ['./animal-form.component.scss'],
})
export class AnimalFormComponent {
  error: any;
  constructor(private service: AnimalService) {}
  loading = false;
  @Output() created = new EventEmitter<Animal>();

  create() {
    this.loading = true;
    this.error = null;
    this.service
      .create({
        name: this.name,
      })
      .subscribe({
        next: (data) => {
          this.created.emit(data);
          this.name = '';
          this.loading = false;
        },
        error: (error) => {
          this.error = error.error?.errors ?? error?.error;
          this.loading = false;
        },
      });
  }
  name = '';
}
