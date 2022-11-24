import { Pregunta } from "./pregunta";

export interface Modulo {
  id_modulo?: number;
  orden?: number;
  codigo?: string;
  nombre?: string;
  descripcion?: string;
  peso?: string;
  imagen?: string;

  preguntas?: Pregunta[]
}
