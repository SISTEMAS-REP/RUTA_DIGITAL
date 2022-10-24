using Microsoft.AspNetCore.Mvc;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorizationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
