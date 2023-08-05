using System.ComponentModel.DataAnnotations;

namespace Barinak.Models
{
    public class GirisYap
    {
        [EmailAddress(ErrorMessage = "Geçerli Mail Girin")]
        [Required(ErrorMessage = "Email Girin")]
        [Display(Name = "Email")]
        public int Mail { get; set; }

        [Required(ErrorMessage = "Şifrenizi Girin")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
    }
}
