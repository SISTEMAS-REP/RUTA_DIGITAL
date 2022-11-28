using Prod.RutaDigital.Entidades;
using Release.Helper.Data.ICore;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<PerfilAvanceEstadisticaResponse>> ListarEstadisticaPerfilAvance(UsuarioExtranet request);
    Task<IEnumerable<PerfilAvancePremioConsumoResponse>> ListarPremioConsumoPerfilAvance(UsuarioExtranet request);
    Task<IEnumerable<ResultadoResponse>> ListarResultadosPerfilAvance(ResultadoRequest request);
    Task<IEnumerable<ResultadoModuloResponse>> ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request);
    Task<IEnumerable<NivelMadurezResponse>> ListarNivelesMadurezPerfilAvance();
}
