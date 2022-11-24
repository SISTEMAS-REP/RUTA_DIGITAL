import { Evaluacion } from './evaluacion';
import { Modulo } from './modulo';
import { Respuesta } from './respuesta';

export interface TestAutodiagnostico {
  evaluacion?: Evaluacion;
  respuestas: Respuesta[];
  modulos?: Modulo[];
}
