using Microsoft.EntityFrameworkCore;
using Barinak.Models;

namespace Barinak.Models
{
    public class BarinakContext: DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<UyeOl> Uyeler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
            Database=Barinak;Trusted_Connection=true;");
        }

        // public DbSet<Barinak.Models.UyeOl>? UyeOl { get; set; }
    }
}
