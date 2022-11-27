import { SafeUrl } from '@angular/platform-browser';
export interface RecursoDet {
  id_recurso_det: number;
  id_recurso: number;
  nombre: string;
  descripcion: string;
  enlace_ruta: SafeUrl;
  icono: string;
}
