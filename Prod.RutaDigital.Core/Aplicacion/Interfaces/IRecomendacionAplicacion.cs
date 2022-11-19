using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IRecomendacionAplicacion
{
    Task<StatusResponse<IEnumerable<RecomendacionResponse>>>
        ListarRecomendaciones(RecomendacionRequest request);
}
