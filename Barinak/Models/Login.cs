using System.ComponentModel.DataAnnotations;

namespace Barinak.Models
{
    public class Login
    {
        public int LoginID { get; set; }

        [Required(ErrorMessage = "Adınızı Girin")]
        [Display(Name = "Ad")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Soyadınızı Girin")]
        [Display(Name = "Soyad")]
        public string Lastname { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli Bir Email Girin")]
        [Required(ErrorMessage = "Email Girin")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi Girin")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler Uyumsuz")]
        [Required(ErrorMessage = "Şifrenizi Girin")]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }

        [Phone(ErrorMessage = "Geçerli Telefon Girin")]
        [Required(ErrorMessage = "Telefonunuzu Girin")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şehrinizi Girin")]
        [Display(Name = "Şehir")]
        public string City { get; set; }
    }
}
