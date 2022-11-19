using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IModuloAplicacion
{
    Task<StatusResponse<IEnumerable<ModuloResponse>>>
        ListarModulos(ModuloRequest request);
}
