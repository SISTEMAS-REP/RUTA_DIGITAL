using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class TipoPremioAplicacion : ITipoPremioAplicacion
{
    private readonly IUnitOfWork _uow;

    public TipoPremioAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<TipoPremio>>>
        ListarTiposPremio()
    {
        var resultado = new StatusResponse<IEnumerable<TipoPremio>>();

        try
        {
            var data = await _uow
                .ListarTiposPremio();

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
