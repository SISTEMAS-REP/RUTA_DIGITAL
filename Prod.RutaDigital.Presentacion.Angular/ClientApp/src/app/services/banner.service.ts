import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BannerService extends BaseService {
  getControllerUrl(): string {
    return 'banner';
  }

  ListarBannerPrincipal = (): Observable<any> => {
    return this.get('ListarBannerPrincipal');
  };

  ListarBannerPiePagina = (): Observable<any> => {
    return this.get('ListarBannerPiePagina');
  };
  
  ListarEventos = (request?: any): Observable<any> => {
    return this.get('ListarEvento', {params: request ? this.setParams(request) : {},});
  };

  ListarPublicidadPremio = (): Observable<any> => {
    return this.get('ListarPublicidadPremio');
  };

  ListarTipoPremio = (): Observable<any> => {
    return this.get('ListarTipoPremio');
  };

  ListarPremio = (request?: any): Observable<any> => {
    return this.get('ListarPremio', {params: request ? this.setParams(request) : {},});
  };

  ListarNivelPremio = (): Observable<any> => {
    return this.get('ListarNivelPremio');
  };

  ListarPuntajePremio = (): Observable<any> => {
    return this.get('ListarPuntajePremio');
  };

  RedireccionarLoginUnico = (request?: any): Observable<any> => {
    return this.get('RedireccionarLoginUnico', {params: request ? this.setParams(request) : {},});
  };
}
