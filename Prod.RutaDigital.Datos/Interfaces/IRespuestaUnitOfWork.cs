using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<RespuestaResponse>>
        ListarRespuestas(RespuestaRequest request);

    Task<int>
        InsertarRespuesta(RespuestaRequest request);

    Task<int>
        ActualizarRespuesta(RespuestaRequest request);
}