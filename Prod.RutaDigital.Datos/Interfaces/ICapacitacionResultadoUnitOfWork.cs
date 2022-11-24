using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<CapacitacionResultadoResponse>>
        ListarCapacitacionesResultado(CapacitacionResultadoRequest request);

    Task<int>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request);

    Task<int>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request);
}