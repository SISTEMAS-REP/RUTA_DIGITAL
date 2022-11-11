import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ComunService } from '../services/comun.service';

@Injectable({
  providedIn: 'root',
})
export class ComunRepository {
  constructor(private comunService: ComunService) {}

  RedireccionarLoginUnico = (request: any): Observable<any> => {
    return this.comunService
      .RedireccionarLoginUnico(request).pipe(
        map((response) => response.data));
  };

  VerificarAutoDiagnosticoHistorico = (request: any): Observable<any> => {
    return this.comunService
      .VerificarAutoDiagnosticoHistorico(request).pipe(
        map((response) => response.data));
  };

  VerificarAutoDiagnostico = (request: any): Observable<any> => {
    return this.comunService
      .VerificarAutoDiagnostico(request).pipe(
        map((response) => response.data));
  };
}
