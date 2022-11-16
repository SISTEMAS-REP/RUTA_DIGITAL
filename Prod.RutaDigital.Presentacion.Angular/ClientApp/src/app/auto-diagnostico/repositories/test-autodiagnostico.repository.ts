import { Injectable } from '@angular/core';
import { TestAutodiagnosticoService } from '../services/test-autodiagnostico.service';

@Injectable({
  providedIn: 'root',
})
export class TestAutodiagnosticoRepository {
  constructor(private testAutodiagnosticoService: TestAutodiagnosticoService) {}
}
