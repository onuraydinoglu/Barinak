using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Barinak.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Cinsini Yazın!")]
        [Display(Name = "Kategorisi")]
        public string KategoriAdi { get; set; }

        public ICollection<Tur>? Turler { get; set; }
    }
}
