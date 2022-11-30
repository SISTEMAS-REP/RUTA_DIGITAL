const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
  ? env.ASPNETCORE_URLS.split(";")[0]
  : "http://localhost:21725";

const PROXY_CONFIG = [
  {
    context: ["/app"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/authorization"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/catalogopremios"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/eventos/ListarEventos"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/inicio"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/weatherforecast"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },

  {
    context: ["/autodiagnostico/VerificarAutodiagnostico"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/autodiagnostico/VerificarAutodiagnosticoHistorico"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/autodiagnostico/ListarTestAutodiagnostico"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/autodiagnostico/ActualizarRespuesta"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/autodiagnostico/ValidarModulo"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/autodiagnostico/ProcesarEvaluacion"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/autodiagnostico/ListarResultadoAutodiagnostico"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },

  {
    context: ["/capacitacion"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/capacitacion/ListarTestAvance"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },

  {
    context: ["/perfilAvance/ListarEstadisticaPerfilAvance"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/perfilAvance/ListarCapacitacionPerfilAvance"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/perfilAvance/ListarResultadoPerfilAvance"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
  {
    context: ["/perfilAvance/ListarPremioConsumoPerfilAvance"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },

  {
    context: ["/autodiagnostico-historico/VerificarAutodiagnosticoHistorico"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },

  {
    context: ["/autodiagnostico-historico/ListarResultadoAutodiagnostico"],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
];

module.exports = PROXY_CONFIG;
