using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface ITipoTestAplicacion
{
    Task<StatusResponse<IEnumerable<TipoTestResponse>>>
        ListarTiposTest(TipoTestRequest request);
}
