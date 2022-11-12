import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class CatalogoPremiosService extends BaseService {
  getControllerUrl(): string {
    return 'catalogopremios';
  }

  listarPublicidadPremio = (): Observable<any> => {
    return this.get('ListarPublicidadPremio');
  };

  listarTipoPremio = (): Observable<any> => {
    return this.get('ListarTipoPremio');
  };

  listarPremio = (request?: any): Observable<any> => {
    return this.get('ListarPremio', {
      params: request ? this.setParams(request) : {},
    });
  };

  listarNivelPremio = (): Observable<any> => {
    return this.get('ListarNivelPremio');
  };

  listarPuntajePremio = (): Observable<any> => {
    return this.get('ListarPuntajePremio');
  };
}
