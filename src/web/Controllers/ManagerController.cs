using Microsoft.AspNetCore.Mvc;

namespace msShop.Controllers
{
    public class ManagerController : Controller
    {
        [HttpGet]
        public IActionResult Manager()
        {

            return View();
        }
    }
}
