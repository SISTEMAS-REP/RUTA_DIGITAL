import { NivelMadurez } from "src/app/autodiagnostico/interfaces/nivel-madurez";
import { Resultado } from "src/app/autodiagnostico/interfaces/resultado";
import { ResultadoModulo } from "src/app/autodiagnostico/interfaces/resultado-modulo";

export interface ResultadoTestAvance {
  resultado: Resultado;
  resultadoModulos: ResultadoModulo[];
  nivelesMadurez: NivelMadurez[];
}
