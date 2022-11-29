import { RespuestaTestRequest } from "./respuesta-test.request";

export interface CapacitacionDetalleRequest {
    id_capacitacion_resultado: number,
    respuestas: RespuestaTestRequest[],
}