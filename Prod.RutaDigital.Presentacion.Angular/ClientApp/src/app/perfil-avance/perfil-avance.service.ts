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

  ListarCalculoPuntosUsuario = (request?: any): Observable<any> => {
    return this.get('ListarCalculoPuntosUsuario', {
      params: request ? this.setParams(request) : {},
    });
  };

  ListarPremioConsumoUsuario = (request?: any): Observable<any> => {
    return this.get('ListarPremioConsumoUsuario', {
      params: request ? this.setParams(request) : {},
    });
  };
}
