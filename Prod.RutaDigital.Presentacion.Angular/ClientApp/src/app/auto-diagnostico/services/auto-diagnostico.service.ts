import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoService extends BaseService {
  getControllerUrl(): string {
    return 'autodiagnostico';
  }

  VerificarAutoDiagnosticoHistorico = (request?: any): Observable<any> => {
    return this.get('VerificarAutoDiagnosticoHistorico', {params: request ? this.setParams(request) : {},});
  };

  VerificarAutoDiagnostico = (request?: any): Observable<any> => {
    return this.get('VerificarAutoDiagnostico', {params: request ? this.setParams(request) : {},});
  };
}
