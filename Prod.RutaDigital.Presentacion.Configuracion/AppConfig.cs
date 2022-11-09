namespace Prod.RutaDigital.Presentacion.Configuracion;

public class AppConfig
{
    public Urls Urls { get; set; }
}

public class Urls
{
    public string URL_GA_UI { get; set; }
    public string URL_RUTA_DIGITAL_CORE_API { get; set; }

    public string URL_LOGIN_UNICO_WEB { get; set; }
    public string URL_LOGIN_UNICO_WEB_NET { get; set; }
    public string URL_LOGIN_UNICO_WEB_CORE_API { get; set; }
}
