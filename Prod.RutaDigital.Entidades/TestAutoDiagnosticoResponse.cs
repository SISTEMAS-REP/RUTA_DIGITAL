namespace Prod.RutaDigital.Entidades;

public class TestAutodiagnosticoResponse
{
    public EvaluacionResponse Evaluacion { get; set; }
    public IEnumerable<RespuestaResponse> Respuestas { get; set; }
    public IEnumerable<ModuloResponse> Modulos { get; set; }
}