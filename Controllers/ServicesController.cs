using Law_Firm.Models.ClsDatabase;
using Law_Firm.Models.dbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Law_Firm.Controllers
{
    // Controller for the Services page
    public class ServicesController : Controller

    {

        Iservicees iserviceesrepost;
        

        public ServicesController(Iservicees _iservicees)
        {
            this.iserviceesrepost = _iservicees; 
        }
        public IActionResult Index()
        {
            // Fetch services using Entity Framework from the Services table
            var services = iserviceesrepost.Get_All()
                .Select(s => new ServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
           
                    SubDescription = s.SubDescription,
                    IconImage = s.IconImage,
                    IMagURL = s.IMagURL,
                    Description = s.Description
                })
                .ToList();

            return View(services);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceModel viewModel)
        {
            if (ModelState.IsValid)
            {
                iserviceesrepost.Add(viewModel);
                iserviceesrepost.Save(); 
                return RedirectToAction("index");
            }

            // If the model is invalid, reload the services list and return to the view
      
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = iserviceesrepost.Find_Using_ID(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = iserviceesrepost.Find_Using_ID(model.Id);
            if (entity == null) return NotFound();

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.SubDescription = model.SubDescription;
            entity.IconImage = model.IconImage;
            entity.IMagURL = model.IMagURL;

            iserviceesrepost.Save(); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = iserviceesrepost.Find_Using_ID(id);
            if (service == null) return NotFound();

            // حوله لـ ViewModel
            var viewModel = new ServivesViewMOdel
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                IMagURL = service.IMagURL
            };

            return View(viewModel);
        }




    }
}
