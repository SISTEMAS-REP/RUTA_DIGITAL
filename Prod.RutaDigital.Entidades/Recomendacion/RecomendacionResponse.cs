namespace Prod.RutaDigital.Entidades;

public class RecomendacionResponse : Recomendacion
{
    public int id_capacitacion_resultado { get; set; }

    public IEnumerable<RecomendacionDetResponse> detalle { get; set; }
    public IEnumerable<RecursoResponse> recursos { get; set; }
}
