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
    context: ["/eventos"],
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
];

module.exports = PROXY_CONFIG;
