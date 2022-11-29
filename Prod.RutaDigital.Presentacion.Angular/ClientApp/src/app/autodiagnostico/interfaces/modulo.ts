import { Pregunta } from './pregunta';
import { NivelMadurez } from './nivel-madurez';
import { CapacitacionResultado } from 'src/app/recomendaciones/interfaces/capacitacion-resultado';

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

  capacitaciones?: CapacitacionResultado[];

  completado?: boolean;
}
