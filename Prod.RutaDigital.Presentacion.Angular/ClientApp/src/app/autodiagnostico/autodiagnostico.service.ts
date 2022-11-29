import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/services/base.service';
import { RespuestaRequest } from './interfaces/request/respuesta.request';
import { ModuloRequest } from './interfaces/request/modulo.request';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoService extends BaseService {
  getControllerUrl(): string {
    return 'autodiagnostico';
  }

  verificarAutodiagnostico = (): Observable<any> => {
    return this.post('VerificarAutodiagnostico', {});
  };

  listarTestAutodiagnostico = (): Observable<any> => {
    return this.get('ListarTestAutodiagnostico', {});
  };

  actualizarRespuesta = (request: RespuestaRequest): Observable<any> => {
    return this.put("ActualizarRespuesta", request);
  }

  validarModulo = (request: ModuloRequest): Observable<any> => {
    return this.post("ValidarModulo", request);
  }

  procesarEvaluacion = (): Observable<any> => {
    return this.post("ProcesarEvaluacion", {});
  }

  listarResultadoAutodiagnostico = (): Observable<any> => {
    return this.get('ListarResultadoAutodiagnostico', {});
  };

  VerificarAutodiagnosticoHistorico = (): Observable<any> => {
    return this.post('VerificarAutodiagnosticoHistorico', {});
  };
}
