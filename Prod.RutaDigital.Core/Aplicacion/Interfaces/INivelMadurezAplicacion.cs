using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface INivelMadurezAplicacion
{
    Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
        ListarNivelesMadurez();
}
