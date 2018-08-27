using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BatturKategoriConfiguration : EntityTypeConfiguration<BatturKategori>
    {
        public BatturKategoriConfiguration()
        {
            this.Property(p => p.BatturKategoriId).HasColumnOrder(0);

            this.Property(p => p.BatturId)
            .IsRequired();

            this.Property(p => p.KategoriId)
            .IsRequired();

            this.Property(p => p.Opprettet)
              .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");
        }
    }
}
