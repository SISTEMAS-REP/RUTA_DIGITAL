using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface ICapacitacionResultadoAplicacion
{
    Task<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>
        ListarCapacitacionResultado(CapacitacionResultadoRequest request);

    Task<StatusResponse<int>>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request);

    Task<StatusResponse<int>>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request);
}
