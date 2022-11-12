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
    public async Task<StatusResponse<IEnumerable<NivelMadurez>>> 
        ListarNivelesMadurez()
    {
        var resultado = new StatusResponse<IEnumerable<NivelMadurez>>();
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
}
