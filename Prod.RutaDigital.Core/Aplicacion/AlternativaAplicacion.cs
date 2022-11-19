using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class AlternativaAplicacion : IAlternativaAplicacion
{
    private readonly IUnitOfWork _uow;

    public AlternativaAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<IEnumerable<AlternativaResponse>>>
        ListarAlternativas(AlternativaRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<AlternativaResponse>>();
        try
        {
            var data = await _uow
                .ListarAlternativas(request);

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
