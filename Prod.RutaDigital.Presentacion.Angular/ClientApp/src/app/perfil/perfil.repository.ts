import { Injectable } from '@angular/core';
import { PerfilService } from './perfil.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilRepository {
  constructor(private perfilService: PerfilService) {}
}
