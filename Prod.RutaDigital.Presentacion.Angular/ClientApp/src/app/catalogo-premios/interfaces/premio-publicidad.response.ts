import { SafeUrl } from '@angular/platform-browser';

export interface PremioPublicidadResponse {
  id_publicidad_premio?: number;
  imagen?: string;
  numArray?: Blob;

  imagenPremioPublicidad?: SafeUrl;
}
