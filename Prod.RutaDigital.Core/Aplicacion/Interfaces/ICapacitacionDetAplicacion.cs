using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface ICapacitacionDetAplicacion
{
    Task<StatusResponse<int>>
        InsertarCapacitacionDet(CapacitacionDetRequest request);
}
