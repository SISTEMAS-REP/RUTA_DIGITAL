using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class UsuarioExtranetAplicacion : IUsuarioExtranetAplicacion
{
    private readonly IUnitOfWork _uow;

    public UsuarioExtranetAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<UsuarioExtranetResponse>>
        BuscarUsuario(UsuarioExtranetRequest request)
    {
        var resultado = new StatusResponse<UsuarioExtranetResponse>();
        try
        {
            var data = await _uow
                .BuscarUsuario(request);

            resultado.Success = true;
            resultado.Data = data;
        }
        catch (Exception ex)
        {
            resultado.Success = true;
            resultado.Messages = new()
            {
                ex.Message
            };
        }

        return resultado;
    }
}
