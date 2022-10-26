using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Release.Helper.Data.Core;

namespace Prod.RutaDigital.Datos.Contexto;

public partial class RutaDbContext : DbContext, IDbContext
{
    private readonly string _connstr;
    private string conn = "Data Source=172.20.11.43;Initial Catalog=DB_RUTADIGITAL_V2;User Id=usr_rutadigital_v2;Password=Nuev4ruta;";
    public RutaDbContext(string connstr)
    {
        this._connstr = connstr;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    public RutaDbContext(DbContextOptions<RutaDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(conn);
        }
    }
}