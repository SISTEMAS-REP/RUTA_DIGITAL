import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ComunService extends BaseService {
  getControllerUrl(): string {
    return 'Comun';
  }

  RedireccionarLoginUnico = (request?: any): Observable<any> => {
    return this.get('RedireccionarLoginUnico', {params: request ? this.setParams(request) : {},});
  };

  VerificarAutoDiagnosticoHistorico = (request?: any): Observable<any> => {
    return this.get('VerificarAutoDiagnosticoHistorico', {params: request ? this.setParams(request) : {},});
  };

  VerificarAutoDiagnostico = (request?: any): Observable<any> => {
    return this.get('VerificarAutoDiagnostico', {params: request ? this.setParams(request) : {},});
  };
}
