import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceService extends BaseService {
  getControllerUrl(): string {
    return 'perfil-avance';
  }
}
