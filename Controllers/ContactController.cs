using Microsoft.AspNetCore.Mvc;
using Law_Firm.Models.ClsDatabase;
using Law_Firm.Reosertiry.Interface;
using System.Threading.Tasks;

namespace Law_Firm.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContact ContactRepo;
        private readonly EmailService _emailService;

        public ContactController(IContact contactRepo, EmailService emailService)
        {
            ContactRepo = contactRepo;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var AllContact = ContactRepo.Get_All();
            return View(AllContact);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                ContactRepo.Add(model);
                ContactRepo.Save();

                string subject = "📩 New Contact Form Submission";
                string body = $@"
            <h3>You received a new contact message</h3>
            <p><b>Name:</b> {model.Name}</p>
            <p><b>Email:</b> {model.Email}</p>
            <p><b>Message:</b><br/>{model.Message}</p>";

                // ابعت الايميل للـ Admin مع Reply-To = ايميل اليوزر
                await _emailService.SendEmailAsync("admin@lawfirm.com", subject, body, model.Email);

                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
