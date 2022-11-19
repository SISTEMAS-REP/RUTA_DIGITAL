namespace Prod.RutaDigital.Entidades;

public class TestAutoDiagnosticoResponse
{
    public EvaluacionResponse Evaluacion { get; set; }
    public IEnumerable<RespuestaResponse> Respuestas { get; set; }
    public IEnumerable<ModuloResponse> Test { get; set; }
}