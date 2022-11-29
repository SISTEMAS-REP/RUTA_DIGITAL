import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { AuthorizeService } from '../authorization/authorize.service';
import { PerfilAvanceService } from './perfil-avance.service';
import { ExtranetUser } from '../shared/interfaces/extranet-user';
import { ResultadoPerfil } from './interfaces/resultado-perfil';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceRepository {
  constructor(private perfilAvanceService: PerfilAvanceService,
    private authorizeService: AuthorizeService,) {}

  obtenerUsuario = (): ExtranetUser => {
    const usuario = this.authorizeService.user;
    console.log('perfil-avance-repository/obtenerUsuario', usuario);
    return usuario;
  };

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


  ListarResultadoPerfilAvance = (): Observable<ResultadoPerfil> => {
    return this.perfilAvanceService.ListarResultadoPerfilAvance().pipe(
      map((response) => response.data as ResultadoPerfil)
    );
  };
}
