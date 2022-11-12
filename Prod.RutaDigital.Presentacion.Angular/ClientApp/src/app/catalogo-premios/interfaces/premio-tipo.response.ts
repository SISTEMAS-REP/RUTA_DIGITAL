import { SafeUrl } from '@angular/platform-browser';

export interface PremioTipoResponse {
  id_tipo_premio?: number;
  descripcion?: string;
  imagen?: string;
  estado?: boolean;
  numArray?: Blob;

  imagenTipoPremio?: SafeUrl;
}
