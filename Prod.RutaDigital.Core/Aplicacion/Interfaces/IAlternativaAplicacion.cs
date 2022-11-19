using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IAlternativaAplicacion
{
    Task<StatusResponse<IEnumerable<AlternativaResponse>>>
        ListarAlternativas(AlternativaRequest request);
}
