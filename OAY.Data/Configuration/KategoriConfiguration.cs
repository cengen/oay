using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class KategoriConfiguration : EntityTypeConfiguration<Kategori>
    {
        public KategoriConfiguration()
        {
         
            this.Property(p => p.KategoriId).HasColumnOrder(0);

            this.Property(p => p.KategoriNavn )
            .IsRequired().HasMaxLength(100);


        }
    }
}
