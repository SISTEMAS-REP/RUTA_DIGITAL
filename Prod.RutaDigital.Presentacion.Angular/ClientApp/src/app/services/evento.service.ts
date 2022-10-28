import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventoService extends BaseService {
  getControllerUrl(): string {
    return 'evento';
  }

  ListarEventos = (): Observable<any> => {
    return this.get('ListarEvento');
  };
}
