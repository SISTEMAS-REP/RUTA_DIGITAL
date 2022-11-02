using Microsoft.EntityFrameworkCore;
using Release.Helper.Data.Core;

namespace Prod.RutaDigital.Datos.Contexto;

public class RutaDbContext : DbContext, IDbContext
{
    private readonly string _connstr;

    public RutaDbContext(string connstr)
    {
        this._connstr = connstr;
    }

    public void SaveChanges(string jsonAuthN)
    {
        //TODO
    }

    public async Task SaveChangesAsync(string jsonAuthN)
    {
        //TODO
        await Task.Delay(0);
    }

    public void SaveAudit()
    {
        //TODO
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!string.IsNullOrWhiteSpace(this._connstr))
        {
            optionsBuilder.UseSqlServer(this._connstr);
        }
    }
}