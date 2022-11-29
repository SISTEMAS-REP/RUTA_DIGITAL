import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';
import { CapacitacionResultado } from './capacitacion-resultado';

export interface TestAvance {
  capacitacionResultado: CapacitacionResultado;
  modulo: Modulo;
}
