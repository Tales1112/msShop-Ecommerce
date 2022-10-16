using Microsoft.AspNetCore.Mvc;
using msShop.Services;

namespace msShop.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
