import { Resultado } from "./resultado";
import { ResultadoModulo } from "./resultado-modulo-historico";
import { NivelMadurez } from './nivel-madurez';

export interface ResultadoAutodiagnosticoHistorico {
  resultado: Resultado;
  resultadoModulos: ResultadoModulo[];
  nivelesMadurez: NivelMadurez[];
}
