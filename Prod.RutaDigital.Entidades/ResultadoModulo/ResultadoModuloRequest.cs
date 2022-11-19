namespace Prod.RutaDigital.Entidades;

public class ResultadoModuloRequest : ResultadoModulo
{
    public IEnumerable<ResultadoPregRequest> pregs { get; set; }
}
