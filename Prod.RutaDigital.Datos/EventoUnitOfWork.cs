using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{ 
    public async Task<IEnumerable<EventoResponse>> 
        ListarEventos(EventoRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_evento", request.id_evento),
             new Parameter("@id_filtro", request.id_filtro),
        };

        var result = ExecuteReader<EventoResponse>(
            "USP_LISTAR_EVENTOS",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
