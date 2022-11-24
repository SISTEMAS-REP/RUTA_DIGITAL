using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<UsuarioExtranetResponse>
        BuscarUsuario(UsuarioExtranetRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
        };

        var result = ExecuteReader<UsuarioExtranetResponse>(
            "USP_MAE_USUARIO_EXTRANET_BUSCAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result.First());
    }

}
