import { RecomendacionDetalle } from './recomendacion-detalle';
import { Recurso } from './recurso';

export interface Recomendacion {
  id_recomendacion: number;
  id_modulo: number;
  id_nivel_madurez: number;
  orden?: number;
  codigo: string;
  descripcion: string;
  puntos_produce: number;
  imagen: string;

  fecha_inicio?: Date;
  calificacion: number;
  concluido: boolean;

  nombre_modulo: string;
  orden_modulo: number;
  nombre_nivel_madurez: string;

  detalle: RecomendacionDetalle[];
  recursos: Recurso[];
}
