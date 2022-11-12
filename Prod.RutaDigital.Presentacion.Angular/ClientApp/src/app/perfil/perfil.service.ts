import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilService extends BaseService {
  getControllerUrl(): string {
    return 'perfil';
  }
}
