import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/services/base.service';
import { CapacitacionResultadoRequest } from '../interfaces/request/capacitacion-resultado.request';
import { CapacitacionDetalleRequest } from '../interfaces/request/capacitaciondet.request';
import { RecomendacionRequest } from '../interfaces/request/recomendacion.request';

@Injectable({
  providedIn: 'root',
})
export class RecomendacionesService extends BaseService {
  getControllerUrl(): string {
    return 'capacitacion';
  }

  listarCapacitaciones = (request?: any): Observable<any> => {
    return this.get('ListarCapacitaciones', {
      params: request ? this.setParams(request) : {},
    });
  };

  listarRecomendacion = (request?: any): Observable<any> => {
    return this.get('ListarRecomendacion', {
      params: request ? this.setParams(request) : {},
    });
  };

  listarTestAvance = (request?: any): Observable<any> => {
    return this.get('ListarTestAvance', {
      params: request ? this.setParams(request) : {},
    });
  };

  validarCapacitacionesErradas = (
    request: RecomendacionRequest
  ): Observable<any> => {
    return this.post('ValidarCapacitacionesErradas', request);
  };

  procesarAvance = (request: CapacitacionDetalleRequest): Observable<any> => {
    return this.post('ProcesarAvance', request);
  };
  
  iniciarCapacitacion = (
    request: CapacitacionResultadoRequest
  ): Observable<any> => {
    return this.put('IniciarCapacitacion', request);
  };

  calificarCapacitacion = (
    request: CapacitacionResultadoRequest
  ): Observable<any> => {
    return this.put('CalificarCapacitacion', request);
  };
}
