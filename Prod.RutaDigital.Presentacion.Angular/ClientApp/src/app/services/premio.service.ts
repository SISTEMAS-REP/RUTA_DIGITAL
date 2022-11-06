import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PremioService extends BaseService {
  getControllerUrl(): string {
    return 'premio';
  }

  ListarPublicidadPremio = (): Observable<any> => {
    return this.get('ListarPublicidadPremio');
  };

  ListarTipoPremio = (): Observable<any> => {
    return this.get('ListarTipoPremio');
  };

  ListarPremio = (): Observable<any> => {
    return this.get('ListarPremio');
  };
}
