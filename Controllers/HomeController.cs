using System.Diagnostics;
using System.Collections.Generic;

namespace Law_Firm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var testimonials = new List<TestimonialModel>
            {
                new TestimonialModel { Id = 1, Author = "Client A", Quote = "This law firm provided excellent service and expert advice.", ImageUrl = "/Img/client1.jpg" },
                new TestimonialModel { Id = 2, Author = "Client B", Quote = "I am very satisfied with the outcome of my case. Highly recommended.", ImageUrl = "/Img/client2.jpg" },
                new TestimonialModel { Id = 3, Author = "Client C", Quote = "Professional, responsive, and effective. A great team to work with.", ImageUrl = "/Img/client3.jpg" }
            };

            var viewModel = new HomeViewModel
            {
                Testimonials = testimonials
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
