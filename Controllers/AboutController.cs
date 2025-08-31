using Microsoft.AspNetCore.Mvc;

namespace Law_Firm.Controllers
{
    // Controller for the About page
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
