import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InicioService extends BaseService {
  getControllerUrl(): string {
    return 'inicio';
  }
}
