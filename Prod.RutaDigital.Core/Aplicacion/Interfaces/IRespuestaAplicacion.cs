using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IRespuestaAplicacion
{
    Task<StatusResponse<IEnumerable<RespuestaResponse>>>
        ListarRespuestas(RespuestaRequest request);

    Task<StatusResponse<int>>
        InsertarRespuesta(RespuestaRequest request);

    Task<StatusResponse<int>>
        ActualizarRespuesta(RespuestaRequest request);
}
