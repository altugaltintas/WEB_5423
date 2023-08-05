using Microsoft.AspNetCore.Mvc;

namespace Area_proje.Areas.Yönetici.Controllers
{
    public class HomeController : Controller
    {

        [Area("Yönetici")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
