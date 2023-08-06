using System.ComponentModel.DataAnnotations;

namespace Barinak.Models
{
    public class UyeOl
    {
        public int UyeOlID { get; set; }

        [Required(ErrorMessage = "Adınızı Girin")]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyadınızı Girin")]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli Bir Email Girin")]
        [Required(ErrorMessage = "Email Girin")]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifrenizi Girin")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        [Compare("Sifre", ErrorMessage = "Şifreler Uyumsuz")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifrenizi Girin")]
        [Display(Name = "Şifre Tekrar")]
        public string SifreKontrol { get; set; }

        [Phone(ErrorMessage = "Geçerli Telefon Girin")]
        [Required(ErrorMessage = "Telefonunuzu Girin")]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Şehrinizi Girin")]
        [Display(Name = "Şehir")]
        public string Şehir { get; set; }

        public string? Role { get; set; }

        internal object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
