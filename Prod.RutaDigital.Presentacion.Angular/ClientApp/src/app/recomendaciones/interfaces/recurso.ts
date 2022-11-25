import { RecursoDet } from './recurso-det';
export interface Recurso {
  id_recurso: number;
  id_recomendacion: number;
  codigo: string;
  descripcion: string;
  icono: string;
  enlace_ruta: string;
  hashtag: string;

  detalle: RecursoDet[]
}
