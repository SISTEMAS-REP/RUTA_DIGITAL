using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IRecomendacionDetAplicacion
{
    Task<StatusResponse<IEnumerable<RecomendacionDetResponse>>>
        ListarRecomendacionDetalles(RecomendacionDetRequest request);
}
