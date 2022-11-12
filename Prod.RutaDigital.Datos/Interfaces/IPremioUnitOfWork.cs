using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<PremioResponse>> 
        ListarPremios(PremioRequest request);

    Task<IEnumerable<Premio>>
        ListarPuntajesPremios();
}
