using Microsoft.AspNetCore.Mvc;

namespace Law_Firm.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
