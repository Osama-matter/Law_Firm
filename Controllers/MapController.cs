using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Law_Firm.Models.ClsDatabase;

namespace Law_Firm.Controllers
{
    // Controller for the Map page
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            // Sample data for office locations
            var locations = new List<LocationModel>
            {
                new LocationModel { Id = 1, Name = "Headquarters", Address = "123 Law Street, Justice City, USA", Phone = "(123) 456-7890", Latitude = 34.0522, Longitude = -118.2437 },
                new LocationModel { Id = 2, Name = "Downtown Branch", Address = "456 Court Avenue, Metroburg, USA", Phone = "(987) 654-3210", Latitude = 40.7128, Longitude = -74.0060 },
                new LocationModel { Id = 3, Name = "Uptown Office", Address = "789 Legal Plaza, Grandview, USA", Phone = "(555) 123-4567", Latitude = 36.1699, Longitude = -115.1398 }
            };
            return View(locations);
        }
    }
}
