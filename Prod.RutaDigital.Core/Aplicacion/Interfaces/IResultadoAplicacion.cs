using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IResultadoAplicacion
{
    Task<StatusResponse<int>>
        InsertarResultado(ResultadoRequest request);
}
