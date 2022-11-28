
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPerfilAvanceAplicacion
{
    Task<StatusResponse<IEnumerable<CalculoPuntosResponse>>> ListarCalculoPuntosUsuario(UsuarioExtranet request);
    Task<StatusResponse<IEnumerable<PremioConsumoResponse>>> ListarPremioConsumoUsuario(UsuarioExtranet request);
    Task<StatusResponse<IEnumerable<ResultadoResponse>>> ListarResultadosPerfilAvance(ResultadoRequest request);
    Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>> ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request);
    Task<StatusResponse<IEnumerable<NivelMadurezResponse>>> ListarNivelesMadurezPerfilAvance();
}
