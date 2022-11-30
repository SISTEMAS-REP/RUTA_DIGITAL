import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoHistoricoService extends BaseService {
  getControllerUrl(): string {
    return 'autodiagnostico-historico';
  }

  verificarAutodiagnosticoHistorico = (): Observable<any> => {
    return this.post('VerificarAutodiagnosticoHistorico', {});
  };

  listarResultadoAutodiagnostico = (): Observable<any> => {
    return this.get('ListarResultadoAutodiagnostico', {});
  };

}
