using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class PublicidadPremioAplicacion : IPublicidadPremioAplicacion
{
    private readonly IUnitOfWork _uow;

    public PublicidadPremioAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<PublicidadPremio>>>
        ListarPublicidadPremio()
    {
        var resultado = new StatusResponse<IEnumerable<PublicidadPremio>>();

        try
        {
            var data = await _uow
                .ListarPublicidadPremio();

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
