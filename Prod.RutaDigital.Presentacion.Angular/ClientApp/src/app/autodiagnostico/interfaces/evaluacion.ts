export interface Evaluacion {
  id_evaluacion?: number;
  id_usuario_extranet?: number;
  fecha_inicio?: Date;
  fecha_fin?: Date;
  modulo_activo?: number;
  pregunta_activa?: number;
  concluido?: boolean;
}
