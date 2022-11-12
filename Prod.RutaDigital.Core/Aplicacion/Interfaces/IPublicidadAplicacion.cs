using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPublicidadAplicacion
{
    Task<StatusResponse<IEnumerable<Publicidad>>>
        ListarPublicidad();
}
