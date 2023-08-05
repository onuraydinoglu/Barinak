using System.ComponentModel.DataAnnotations;

namespace Barinak.Models
{
    public class Tur
    {
        public int TurID { get; set; }

        [Required(ErrorMessage = "Cinsini Girin")]
        [Display(Name = "Cinsi")]
        public string TurCins { get; set; }

        [Required(ErrorMessage = "Adını Girin")]
        [Display(Name = "Adı")]
        public string TurAd { get; set; }

        [Required(ErrorMessage = "Yaşını Girin")]
        [Display(Name = "Yaşı")]
        public string TurYas { get; set; }

        public int KategoriID { get; set; }

        public Kategori Kategori { get; set; }
    }
}
