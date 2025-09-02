using Law_Firm.Models.ClsDatabase;
using System.Collections.Generic;

namespace Law_Firm.ViewMOdel
{
    public class HomeViewModel
    {
        public IEnumerable<TestimonialModel> Testimonials { get; set; }
    }
}
