import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CatalogoPremiosService } from './catalogo-premios.service';
import { PremioNivelResponse } from './interfaces/premio-nivel.response';
import { PremioPublicidadResponse } from './interfaces/premio-publicidad.response';
import { PremioPuntajeResponse } from './interfaces/premio-puntaje.response';
import { PremioTipoResponse } from './interfaces/premio-tipo.response';
import { PremioResponse } from './interfaces/premio.response';

@Injectable({
  providedIn: 'root',
})
export class CatalogoPremiosRepository {
  constructor(private catalogoPremiosService: CatalogoPremiosService) {}

  listarPublicidadPremio = (): Observable<PremioPublicidadResponse[]> => {
    return this.catalogoPremiosService
      .listarPublicidadPremio()
      .pipe(map((response) => response.data as PremioPublicidadResponse[]));
  };

  listarTipoPremio = (): Observable<PremioTipoResponse[]> => {
    return this.catalogoPremiosService
      .listarTipoPremio()
      .pipe(map((response) => response.data as PremioTipoResponse[]));
  };

  listarPremio = (request: any): Observable<PremioResponse[]> => {
    return this.catalogoPremiosService
      .listarPremio(request)
      .pipe(map((response) => response.data as PremioResponse[]));
  };

  listarPuntajePremio = (): Observable<PremioPuntajeResponse[]> => {
    return this.catalogoPremiosService
      .listarPuntajePremio()
      .pipe(map((response) => response.data as PremioPuntajeResponse[]));
  };

  listarNivelPremio = (): Observable<PremioNivelResponse[]> => {
    return this.catalogoPremiosService
      .listarNivelPremio()
      .pipe(map((response) => response.data as PremioNivelResponse[]));
  };

  CanjePremio = (request: any): Observable<PremioResponse[]> => {
    return this.catalogoPremiosService
      .CanjePremio(request)
      .pipe(map((response) => response.data as PremioResponse[]));
  };
}
