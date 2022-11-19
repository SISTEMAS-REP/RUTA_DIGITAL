using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class ModuloAplicacion : IModuloAplicacion
{
    private readonly IUnitOfWork _uow;

    public ModuloAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<IEnumerable<ModuloResponse>>> 
        ListarModulos(ModuloRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<ModuloResponse>>();
        try
        {
            var data = await _uow
                .ListarModulos(request);

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
