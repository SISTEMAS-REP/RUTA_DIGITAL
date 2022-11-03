import { SafeUrl } from "@angular/platform-browser";

export interface BannerResponse {
    foto: string;
    titulo: string;
    nombre_empresa: string;
    tipo_empresa: string;
    url_web: string;
    accion: string;
    numArray?: Blob;
    imagenBanner?: SafeUrl;
  }
  