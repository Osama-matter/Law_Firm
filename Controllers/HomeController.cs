using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Law_Firm.Models;
using Law_Firm.Models.ClsDatabase;

namespace Law_Firm.Controllers
{
    // Controller for the Home page
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
