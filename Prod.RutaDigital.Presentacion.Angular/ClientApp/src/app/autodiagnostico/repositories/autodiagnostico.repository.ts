import { Injectable } from '@angular/core';
import { AutodiagnosticoService } from '../services/autodiagnostico.service';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoRepository {
  constructor(private autodiagnosticoService: AutodiagnosticoService) {}
}
