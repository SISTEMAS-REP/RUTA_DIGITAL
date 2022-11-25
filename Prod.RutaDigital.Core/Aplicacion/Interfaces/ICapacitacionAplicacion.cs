using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface ICapacitacionAplicacion
{
    Task<StatusResponse<int>>
        InsertarCapacitacion(CapacitacionRequest request);
}
