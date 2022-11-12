using Prod.RutaDigital.Datos.Interfaces;
using Release.Helper.Data.Core;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    public UnitOfWork(IDbContext context)
        : base(context, true)
    {

    }

    public void ExecDispose()
    {
        Dispose();
    }
}