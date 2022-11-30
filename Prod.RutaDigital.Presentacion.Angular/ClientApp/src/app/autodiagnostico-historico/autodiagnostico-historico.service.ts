import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoHistoricoService extends BaseService {
  getControllerUrl(): string {
    return 'autoDiagnosticoHistorico';
  }

  verificarAutodiagnosticoHistorico = (): Observable<any> => {
    return this.post('VerificarAutodiagnosticoHistorico', {});
  };

  listarResultadoAutodiagnosticoHistorico = (): Observable<any> => {
    return this.get('listarResultadoAutodiagnosticoHistorico', {});
  };

}
