using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPreguntaAplicacion
{
    Task<StatusResponse<IEnumerable<PreguntaResponse>>>
        ListarPreguntas(PreguntaRequest request);
}
