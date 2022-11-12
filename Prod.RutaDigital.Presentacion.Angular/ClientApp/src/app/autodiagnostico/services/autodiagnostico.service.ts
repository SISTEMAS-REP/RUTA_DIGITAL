import { Injectable } from '@angular/core';
import { BaseService } from '../../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoService extends BaseService {
  getControllerUrl(): string {
    return 'autodiagnostico';
  }
}
