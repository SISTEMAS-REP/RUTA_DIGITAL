import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BannerService extends BaseService {
  getControllerUrl(): string {
    return 'banner';
  }

  ListarBannerPrincipal = (): Observable<any> => {
    return this.get('ListarBannerPrincipal');
  };

  ListarBannerPiePagina = (): Observable<any> => {
    return this.get('ListarBannerPiePagina');
  };
}
