import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/services/base.service';
import { TestAvanceRequest } from '../interfaces/request/test-avance.request';

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

  procesarAvance = (request: TestAvanceRequest): Observable<any> => {
    return this.post('Procesaravance', request);
  }
}
