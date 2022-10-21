using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Prod.RutaDigital.Core.Aplicacion;

public static class xHelper
{
    public static T ConvertToViewModel<T>(object obj) where T : class
    {
        var mo = JsonConvert.DeserializeObject<T>(JObject.FromObject(obj).ToString());
        return mo;
    }
}
