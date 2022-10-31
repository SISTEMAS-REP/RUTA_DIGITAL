using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos
{
    public class EventoUnitOfWork : UnitOfWork, IEventoUnitOfWork
    {
        public EventoUnitOfWork(IDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<EventoResponse>> ListarEventos(EventoRequest request)
        {
            var parms = new Parameter[]
            {
                 new Parameter("@id_evento", request.id_evento),
                 new Parameter("@id_filtro", request.id_filtro),
            };

            var result = ExecuteReader<EventoResponse>(
                "Usp_listar_eventos",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }
    }
}
