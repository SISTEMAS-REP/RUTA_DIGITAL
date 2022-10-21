using Release.Helper.Data.Core;

namespace Prod.RutaDigital.Datos.Comun;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
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