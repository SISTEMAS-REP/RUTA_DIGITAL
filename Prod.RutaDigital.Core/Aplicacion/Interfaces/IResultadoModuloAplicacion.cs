using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IResultadoModuloAplicacion
{
    Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
        ListarResultadoModulos(ResultadoModuloRequest request);

    Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
     ListarResultadoModulosHistorico(ResultadoModuloRequest request);

    Task<StatusResponse<int>>
        InsertarResultadoModulo(ResultadoModuloRequest request);
}
