using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPremioAplicacion
{
    Task<StatusResponse<IEnumerable<PremioResponse>>> 
        ListarPremios(PremioRequest request);

    Task<StatusResponse<IEnumerable<Premio>>>
        ListarPuntajesPremios();
}
