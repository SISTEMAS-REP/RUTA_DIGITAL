import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AutodiagnosticoService } from '../services/autodiagnostico.service';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoRepository {
  constructor(private autodiagnosticoService: AutodiagnosticoService) {}

  VerificarAutoDiagnosticoHistorico = (request: any): Observable<any> => {
    return this.autodiagnosticoService
      .VerificarAutoDiagnosticoHistorico(request).pipe(
        map((response) => response.data));
  };

  VerificarAutoDiagnostico = (request: any): Observable<any> => {
    return this.autodiagnosticoService
      .VerificarAutoDiagnostico(request).pipe(
        map((response) => response.data));
  };
}
