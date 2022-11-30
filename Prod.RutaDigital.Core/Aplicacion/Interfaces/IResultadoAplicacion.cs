using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IResultadoAplicacion
{
    Task<StatusResponse<IEnumerable<ResultadoResponse>>>
        ListarResultados(ResultadoRequest request);
    Task<StatusResponse<IEnumerable<ResultadoResponse>>>
       ListarResultadosHistorico(ResultadoRequest request);

    Task<StatusResponse<int>>
        InsertarResultado(ResultadoRequest request);
}
