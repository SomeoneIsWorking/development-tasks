import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Animal } from '../animal.model';
import { AnimalService } from '../animal.service';

@Component({
  selector: 'app-animal-row',
  templateUrl: './animal-row.component.html',
  styleUrls: ['./animal-row.component.scss'],
})
export class AnimalRowComponent {
  @Output() deleted = new EventEmitter();

  constructor(private service: AnimalService) {}
  askConfirmation = false;
  remove() {
    this.service.delete(this.data.id!).subscribe({
      next: () => {
        this.deleted.emit();
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      },
    });
  }
  @Input() data!: Animal;
  loading = false;
}
