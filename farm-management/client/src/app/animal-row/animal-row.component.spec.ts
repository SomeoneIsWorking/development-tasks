import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalRowComponent } from './animal-row.component';

describe('AnimalRowComponent', () => {
  let component: AnimalRowComponent;
  let fixture: ComponentFixture<AnimalRowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AnimalRowComponent]
    });
    fixture = TestBed.createComponent(AnimalRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
