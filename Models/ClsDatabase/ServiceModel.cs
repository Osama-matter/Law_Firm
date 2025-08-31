using System.ComponentModel.DataAnnotations;

namespace Law_Firm.Models.ClsDatabase
{
    // Model for legal services
    public class ServiceModel
    {
        [Key ]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string  IMagURL  { get; set; }  
    }
}
