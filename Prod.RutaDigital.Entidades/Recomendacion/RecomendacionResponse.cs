﻿namespace Prod.RutaDigital.Entidades;

public class RecomendacionResponse : Recomendacion
{
    //public int id_capacitacion_resultado { get; set; }
    public string? nombre_modulo { get; set; }
    public int orden_modulo { get; set; }
    public string? nombre_nivel_madurez { get; set; }

    public DateTime? fecha_inicio { get; set; }
    public int? progreso { get;set; }
    public int calificacion { get; set; }
    public bool concluido { get; set; }

    public IEnumerable<RecomendacionDetResponse>? detalle { get; set; }
    public IEnumerable<RecursoResponse>? recursos { get; set; }
}
