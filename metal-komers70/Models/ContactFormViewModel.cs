using System.ComponentModel.DataAnnotations;

namespace metal_komers70.Models
{
    public class ContactFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
