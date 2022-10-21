using Microsoft.EntityFrameworkCore;
using Release.Helper.Data.Core;

namespace Prod.RutaDigital.Datos.Contexto;

public class RutaDbContext : DbContext, IDbContext
{
    public void SaveAudit()
    {
        throw new NotImplementedException();
    }

    public void SaveChanges(string jsonAuthN)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(string jsonAuthN)
    {
        throw new NotImplementedException();
    }
}