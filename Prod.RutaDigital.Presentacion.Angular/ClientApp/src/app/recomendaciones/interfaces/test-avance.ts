import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';
import { CapacitacionResponse } from './capacitacion-resultado';

export interface TestAvance {
  capacitacionResultado: CapacitacionResponse;
  modulo: Modulo;
}
