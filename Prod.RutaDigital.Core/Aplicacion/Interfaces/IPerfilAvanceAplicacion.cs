
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPerfilAvanceAplicacion
{
    Task<StatusResponse<IEnumerable<PerfilAvanceEstadisticaResponse>>> ListarEstadisticaPerfilAvance(UsuarioExtranet request);
    Task<StatusResponse<IEnumerable<PerfilAvancePremioConsumoResponse>>> ListarPremioConsumoPerfilAvance(UsuarioExtranet request);
    Task<StatusResponse<IEnumerable<ResultadoResponse>>> ListarResultadosPerfilAvance(ResultadoRequest request);
    Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>> ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request);
    Task<StatusResponse<IEnumerable<NivelMadurezResponse>>> ListarNivelesMadurezPerfilAvance();
    Task<StatusResponse<IEnumerable<RecomendacionResponse>>> ListarCapacitacionPerfilAvance(UsuarioExtranet request);
}
