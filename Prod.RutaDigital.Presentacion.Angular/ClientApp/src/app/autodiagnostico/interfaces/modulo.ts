import { Pregunta } from './pregunta';
import { NivelMadurez } from './nivel-madurez';
import { CapacitacionResultadoRequest } from 'src/app/recomendaciones/interfaces/request/capacitacion-resultado.request';

export interface Modulo {
  id_modulo?: number;
  orden?: number;
  codigo?: string;
  nombre?: string;
  descripcion?: string;
  peso?: string;
  imagen?: string;

  preguntas?: Pregunta[];

  niveles?: NivelMadurez[];

  capacitaciones?: CapacitacionResultadoRequest[];

  completado?: boolean;
}
