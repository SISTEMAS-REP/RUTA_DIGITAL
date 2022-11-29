export interface CapacitacionResultado {
  id_capacitacion_resultado: number;
  id_resultado: number;
  id_recomendacion: number;
  fecha_inicio: Date;
  fecha_fin: Date;
  progreso: number;
  concluido: boolean;
  clasificacion: number;

  id_modulo: number;
  orden_modulo: number;
  nombre_modulo: string;

  id_nivel_madurez: number;
  nombre_nivel_madurez: string;

  orden_recomendacion: number;
  descripcion_recomendacion: string;
  imagen_recomendacion: string;
}
