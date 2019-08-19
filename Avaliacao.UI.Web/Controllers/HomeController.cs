using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
