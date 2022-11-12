import { SafeUrl } from '@angular/platform-browser';

export interface PremioResponse {
  id_premio?: number;
  id_tipo_premio?: number;
  tipo_premio?: string;
  id_nivel_madurez?: number;
  id_tipo_canje?: number;
  foto?: string;
  nombre?: string;
  descripcion_corta?: string;
  detalle_premio?: string;
  puntos_produce?: number;
  correo?: string;

  nivel_madurez?: string;
  tipo_canje?: string;
  numArray?: Blob;

  imagenPremio?: SafeUrl;

  etiqueta?: string;
  foto_tipo?: string;
  fotoTipoArray?: Blob;

  imagenTipoPremio?: SafeUrl;
}
