import { SafeUrl } from "@angular/platform-browser";

export interface PremioPublicidadResponse {
    // foto: string;
    id_publicidad_premio?: number;
    imagen?: string;
    numArray?: Blob;
    imagenPremioPublicidad?: SafeUrl;
}

export interface PremioTipoResponse {
    // foto: string;
    id_tipo_premio?: number;
    descripcion?: string;
    imagen?: string;
    numArray?: Blob;
    imagenTipoPremio?: SafeUrl;
}
  
export interface PremioResponse {
    id_premio?: number;
    id_tipo_premio?: number;
    tipo_premio? : string;
    id_nivel_madurez?: number;
    nivel_madurez?: string;
    id_tipo_canje?: number;
    tipo_canje?: string;
    foto?: string;
    nombre?: string;
    descripcion_corta?: string;
    detalle_premio?: string;
    puntos_produce? : number;
    correo? : string;
    numArray?: Blob;
    imagenPremio?: SafeUrl;
}
  