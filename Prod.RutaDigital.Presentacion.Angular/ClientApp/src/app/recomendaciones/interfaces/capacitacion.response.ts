import { NivelMadurez } from 'src/app/autodiagnostico/interfaces/nivel-madurez';
import { CapacitacionResponse } from './capacitacion-resultado'
export interface Capacitacion {
    niveles:        NivelMadurez[];
    capacitaciones: CapacitacionResponse[];
}
