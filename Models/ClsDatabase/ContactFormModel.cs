using System.ComponentModel.DataAnnotations;

namespace Law_Firm.Models.ClsDatabase
{
    // Model for the contact form
    public class ContactFormModel
    {
        [key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }
    }
}
