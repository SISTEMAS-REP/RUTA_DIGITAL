import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { PerfilAvanceService } from './perfil-avance.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceRepository {
  constructor(private perfilAvanceService: PerfilAvanceService) {}

  ListarCalculoPuntosUsuario = (request: any): Observable<any[]> => {
    return this.perfilAvanceService
      .ListarCalculoPuntosUsuario(request)
      .pipe(map((response) => response.data as any[]));
  };

  ListarPremioConsumoUsuario = (request: any): Observable<any[]> => {
    return this.perfilAvanceService
      .ListarPremioConsumoUsuario(request)
      .pipe(map((response) => response.data as any[]));
  };

}
