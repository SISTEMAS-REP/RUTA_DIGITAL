using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface ICapacitacionAplicacion
{
    Task<StatusResponse<IEnumerable<CapacitacionResponse>>>
        ListarCapacitaciones(CapacitacionRequest request);

    Task<StatusResponse<int>>
        InsertarCapacitacion(CapacitacionRequest request);
}
