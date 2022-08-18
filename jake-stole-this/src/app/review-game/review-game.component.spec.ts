import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewGameComponent } from './review-game.component';

describe('ReviewGameComponent', () => {
  let component: ReviewGameComponent;
  let fixture: ComponentFixture<ReviewGameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReviewGameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReviewGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
