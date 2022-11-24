using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IRecursoDetAplicacion
{
    Task<StatusResponse<IEnumerable<RecursoDetResponse>>>
        ListarRecursoDetalles(RecursoDetRequest request);
}
