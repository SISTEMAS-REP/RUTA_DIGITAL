using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IAvanceModuloAplicacion
{
    Task<StatusResponse<IEnumerable<AvanceModuloResponse>>>
        ListarAvancesModulos(AvanceModuloRequest request);

    Task<StatusResponse<int>>
        InsertarAvanceModulo(AvanceModuloRequest request);
}
