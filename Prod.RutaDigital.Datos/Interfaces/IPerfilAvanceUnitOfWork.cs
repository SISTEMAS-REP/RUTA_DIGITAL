using Prod.RutaDigital.Entidades;
using Release.Helper.Data.ICore;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<CalculoPuntosResponse>>ListarCalculoPuntosUsuario(UsuarioExtranet request);
    Task<IEnumerable<PremioConsumoResponse>> ListarPremioConsumoUsuario(UsuarioExtranet request);
    Task<IEnumerable<ResultadoResponse>> ListarResultadosPerfilAvance(ResultadoRequest request);
    Task<IEnumerable<ResultadoModuloResponse>> ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request);
    Task<IEnumerable<NivelMadurezResponse>> ListarNivelesMadurezPerfilAvance();
}
