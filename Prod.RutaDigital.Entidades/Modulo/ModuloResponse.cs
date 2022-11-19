namespace Prod.RutaDigital.Entidades;

public class ModuloResponse : Modulo
{
    public IEnumerable<PreguntaResponse> preguntas { get; set; }
}
