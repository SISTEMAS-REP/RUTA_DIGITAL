using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IRecursoAplicacion
{
    Task<StatusResponse<IEnumerable<RecursoResponse>>>
        ListarRecursos(RecursoRequest request);
}
