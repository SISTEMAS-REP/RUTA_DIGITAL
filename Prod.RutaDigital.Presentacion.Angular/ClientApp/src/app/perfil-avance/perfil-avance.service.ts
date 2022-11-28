import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceService extends BaseService {
  getControllerUrl(): string {
    return 'perfilAvance';
  }

  ListarEstadisticaPerfilAvance = (request?: any): Observable<any> => {
    return this.get('ListarEstadisticaPerfilAvance', {
      params: request ? this.setParams(request) : {},
    });
  };

  ListarPremioConsumoPerfilAvance = (request?: any): Observable<any> => {
    return this.get('ListarPremioConsumoPerfilAvance', {
      params: request ? this.setParams(request) : {},
    });
  };
}
