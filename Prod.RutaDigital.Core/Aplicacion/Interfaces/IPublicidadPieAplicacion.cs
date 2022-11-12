using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPublicidadPieAplicacion
{
    Task<StatusResponse<IEnumerable<PublicidadPie>>>
        ListarPublicidadPie();
}
