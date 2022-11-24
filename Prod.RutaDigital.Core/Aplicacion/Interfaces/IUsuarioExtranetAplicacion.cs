using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IUsuarioExtranetAplicacion
{
    Task<StatusResponse<UsuarioExtranetResponse>>
        BuscarUsuario(UsuarioExtranetRequest request);
}
