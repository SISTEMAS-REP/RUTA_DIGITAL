import { NivelMadurez } from 'src/app/autodiagnostico/interfaces/nivel-madurez';
import { CapacitacionResultado } from './capacitacion-resultado'
export interface Capacitacion {
    niveles:        NivelMadurez[];
    capacitaciones: CapacitacionResultado[];
}
