import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PremiosDetalleComponent } from './premios-detalle.component';

describe('PremiosDetalleComponent', () => {
  let component: PremiosDetalleComponent;
  let fixture: ComponentFixture<PremiosDetalleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PremiosDetalleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PremiosDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
