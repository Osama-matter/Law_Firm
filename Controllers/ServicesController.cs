using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Law_Firm.Models.ClsDatabase;
using Law_Firm.Reosertiry.Interface;
using Law_Firm.ViewMOdel;

namespace Law_Firm.Controllers
{
    // Controller for the Services page
    public class ServicesController : Controller
    {

        Iservicees iserviceesrepo; 


        public ServicesController(Iservicees iservicees)
        {
            iserviceesrepo = iservicees;      
        }
        public IActionResult Index()
        {
            // Sample data for services
            var services = iserviceesrepo.Get_All();
     
            return View(services);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceModel  servivesViewMOdel )
        {
            if(ModelState.IsValid)
            {
                iserviceesrepo.Add(servivesViewMOdel);

                iserviceesrepo.Save(); 
            }

            return View(servivesViewMOdel);  
        }

    }
}
