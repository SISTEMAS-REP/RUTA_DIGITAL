import { Injectable } from '@angular/core';
import { PerfilAvanceService } from './perfil-avance.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceRepository {
  constructor(private perfilAvanceService: PerfilAvanceService) {}
}
