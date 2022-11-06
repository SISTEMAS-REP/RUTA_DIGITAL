import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PremiosListadoComponent } from './premios-listado.component';

describe('PremiosListadoComponent', () => {
  let component: PremiosListadoComponent;
  let fixture: ComponentFixture<PremiosListadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PremiosListadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PremiosListadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
