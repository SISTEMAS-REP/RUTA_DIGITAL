export interface Respuesta {
  id_respuesta?: number;
  id_evaluacion?: number;
  id_modulo?: number;
  peso_modulo?: number;
  id_pregunta?: number;
  id_alternativa?: number;
  peso_alt?: number;
  respuesta?: boolean;

  orden_modulo?: number;
  nombre_modulo?: string;
  descripcion_modulo?: string;
  imagen_modulo?: string;

  orden_pregunta?: number;
  descripcion_pregunta?: string;

  orden_alternativa?: number;
  descripcion_alternativa?: string;
}
