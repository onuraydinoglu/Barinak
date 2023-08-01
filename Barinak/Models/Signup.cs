using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Barinak.Models
{
    public class Signup
    {
        [EmailAddress(ErrorMessage = "Geçerli Mail Girin")]
        [Required(ErrorMessage = "Email Girin")]
        [Display(Name = "Email")]
        public int Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi Girin")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
