import { CapacitacionDetRequest } from "./capacitacion-det.request";

export interface TestAvanceRequest {
    id_capacitacion_resultado: number;
    respuestas?: CapacitacionDetRequest[];
}