using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPublicidadPremioAplicacion
{
    Task<StatusResponse<IEnumerable<PublicidadPremio>>>
        ListarPublicidadPremio();
}
