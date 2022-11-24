namespace Prod.RutaDigital.Entidades;

public class ResultadoRequest : Resultado
{
    public IEnumerable<ResultadoModuloRequest>? modulos { get; set; }
}
