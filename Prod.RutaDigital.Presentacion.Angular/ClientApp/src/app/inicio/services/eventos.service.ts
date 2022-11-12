import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class EventosService extends BaseService {
  getControllerUrl(): string {
    return 'eventos';
  }

  listarEventos = (request?: any): Observable<any> => {
    return this.get('ListarEventos', {
      params: request ? this.setParams(request) : {},
    });
  };
}
