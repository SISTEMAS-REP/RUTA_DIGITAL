export interface Alternativa {
    id_alternativa: number;
    id_pregunta: number;
    orden: number;
    codigo: string;
    descripcion: string;
    peso:  number;

    respuesta?: boolean;
}