import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoDiagnosticoDetalleComponent } from './resultado-diagnostico-detalle.component';

describe('ResultadoDiagnosticoDetalleComponent', () => {
  let component: ResultadoDiagnosticoDetalleComponent;
  let fixture: ComponentFixture<ResultadoDiagnosticoDetalleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultadoDiagnosticoDetalleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultadoDiagnosticoDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
