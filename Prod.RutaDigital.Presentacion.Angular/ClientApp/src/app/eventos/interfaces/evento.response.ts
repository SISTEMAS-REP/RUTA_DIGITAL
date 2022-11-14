import { SafeUrl } from '@angular/platform-browser';

export interface EventoResponse {
  // foto: string;
  id_evento?: number;
  id_tipo_modalidad?: number;
  foto?: SafeUrl;
  nombre?: string;
  descripcion_corta?: string;
  descripcion?: string;
  lugar?: string;
  direccion?: string;
  url_evento?: string;
  fecha_evento?: Date;
  modalidad?: string;
  latitud?: number;
  longitud?: number;
  plataforma?: string;
  numArray?: Blob;
  imagenEvento?: SafeUrl;
}
