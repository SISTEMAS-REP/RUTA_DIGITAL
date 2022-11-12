import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class InicioService extends BaseService {
  getControllerUrl(): string {
    return 'inicio';
  }

  listarBannerPrincipal = (): Observable<any> => {
    return this.get('ListarBannerPrincipal');
  };

  listarBannerPiePagina = (): Observable<any> => {
    return this.get('ListarBannerPiePagina');
  };
}
