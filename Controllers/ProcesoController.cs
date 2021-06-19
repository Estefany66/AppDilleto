using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppDilleto.Controllers
{
    public class ProcesoController : Controller
    
    {
        private readonly ILogger<ProcesoController> _logger;

        public ProcesoController(ILogger<ProcesoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}