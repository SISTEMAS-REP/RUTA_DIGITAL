import { Respuesta } from './respuesta';
import { TipoRespuesta } from '../../shared/enums/tipo-respuesta.enum';
import { Alternativa } from './alternativa';

export interface Pregunta {
  id_pregunta?: number;
  id_modulo?: number;
  id_tipo_test?: number;
  id_recomendacion?: number;
  id_tipo_respuesta?: TipoRespuesta;
  orden?: number;
  codigo?: string;
  descripcion?: string;

  respuestas?: Respuesta[];

  alternativas?: Alternativa[];
}
