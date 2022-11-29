import { Resultado } from "./resultado";
import { ResultadoModulo } from "./resultado-modulo";
import { NivelMadurez } from './nivel-madurez';

export interface ResultadoPerfil {
  resultado: Resultado;
  resultadoModulos: ResultadoModulo[];
  nivelesMadurez: NivelMadurez[];
}
