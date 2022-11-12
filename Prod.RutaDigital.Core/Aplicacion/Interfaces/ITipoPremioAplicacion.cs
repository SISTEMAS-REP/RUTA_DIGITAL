using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface ITipoPremioAplicacion
{
    Task<StatusResponse<IEnumerable<TipoPremio>>>
        ListarTiposPremio();
}
