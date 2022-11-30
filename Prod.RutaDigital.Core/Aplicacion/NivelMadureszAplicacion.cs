using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class NivelMadureszAplicacion : INivelMadurezAplicacion
{
    private readonly IUnitOfWork _uow;

    public NivelMadureszAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>> 
        ListarNivelesMadurez()
    {
        var resultado = new StatusResponse<IEnumerable<NivelMadurezResponse>>();
        try
        {
            var data = await _uow
                .ListarNivelesMadurez();

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

    public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
       ListarNivelesMadurezHistorico()
    {
        var resultado = new StatusResponse<IEnumerable<NivelMadurezResponse>>();
        try
        {
            var data = await _uow
                .ListarNivelesMadurezHistorico();

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
