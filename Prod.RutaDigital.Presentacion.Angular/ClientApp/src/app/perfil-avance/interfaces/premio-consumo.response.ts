import { SafeUrl } from '@angular/platform-browser';

export interface PremioConsumoResponse {
  id_premio?: number;
  nombre_premio?: string;
  descripcion?: string;
  foto?: string;
  puntos_consumo?: number;
  fecha_consumo?: Date;
  numArray?: Blob;
  imagenPremio?: SafeUrl;
}
