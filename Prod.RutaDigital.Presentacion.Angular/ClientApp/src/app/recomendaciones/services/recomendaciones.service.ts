import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/services/base.service';
import { CapacitacionDetalleRequest } from '../interfaces/request/capacitaciondet.request';

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

  procesarAvance = (request: CapacitacionDetalleRequest): Observable<any> => {
    return this.post('ProcesarAvance', request);
  }
  iniciarCapacitacion = (request: number): Observable<any> => {
    return this.post('IniciarCapacitacion', request);
  }
  calificarCapacitacion = (request: number): Observable<any> => {
    return this.post('CalificarCapacitacion', request);
  }
}
