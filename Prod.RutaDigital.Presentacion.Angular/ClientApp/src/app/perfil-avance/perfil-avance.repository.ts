import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { PerfilAvanceService } from './perfil-avance.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceRepository {
  constructor(private perfilAvanceService: PerfilAvanceService) {}

  ListarEstadisticaPerfilAvance = (request: any): Observable<any[]> => {
    return this.perfilAvanceService
      .ListarEstadisticaPerfilAvance(request)
      .pipe(map((response) => response.data as any[]));
  };

  ListarPremioConsumoPerfilAvance = (request: any): Observable<any[]> => {
    return this.perfilAvanceService
      .ListarPremioConsumoPerfilAvance(request)
      .pipe(map((response) => response.data as any[]));
  };

  ListarCapacitacionPerfilAvance = (request: any): Observable<any[]> => {
    return this.perfilAvanceService
      .ListarCapacitacionPerfilAvance(request)
      .pipe(map((response) => response.data as any[]));
  };

  ListarResultadoPerfilAvance = (): Observable<any[]> => {
    return this.perfilAvanceService
      .ListarResultadoPerfilAvance()
      .pipe(map((response) => response.data as any[]));
  };
}
