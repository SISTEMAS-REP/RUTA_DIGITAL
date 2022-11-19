using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IResultadoPregAplicacion
{
    Task<StatusResponse<int>>
        InsertarResultadoPreg(ResultadoPregRequest request);
}
