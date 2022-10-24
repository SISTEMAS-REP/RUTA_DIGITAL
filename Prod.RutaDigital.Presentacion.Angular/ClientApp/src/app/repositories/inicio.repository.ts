import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { InicioService } from '../services/inicio.service';

@Injectable({
  providedIn: 'root',
})
export class InicioRepository {
  constructor(private inicioService: InicioService) {}
}
