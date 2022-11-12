import { Injectable } from '@angular/core';
import { BaseService } from '../../shared/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class TestAutodiagnosticoService extends BaseService {
  getControllerUrl(): string {
    return 'testautodiagnostico';
  }
}
