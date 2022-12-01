using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class AvanceModuloAplicacion : IAvanceModuloAplicacion
{
    private readonly IUnitOfWork _uow;

    public AvanceModuloAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<AvanceModuloResponse>>>
        ListarAvancesModulos(AvanceModuloRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<AvanceModuloResponse>>();
        try
        {
            var data = await _uow
                .ListarAvancesModulos(request);

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

    public async Task<StatusResponse<int>>
        InsertarAvanceModulo(AvanceModuloRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarAvanceModulo(request);

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
