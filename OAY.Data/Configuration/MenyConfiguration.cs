using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class MenyConfiguration : EntityTypeConfiguration<Meny>
    {
        public MenyConfiguration()
        {

            this.Property(p => p.MenyId).HasColumnOrder(0);

            this.Property(p => p.Type)
             .IsRequired();

            this.Property(p => p.Beskrivelse)
                .IsRequired();

            this.Property(p => p.EngelskBeskrivelse)
               .IsRequired();

            this.Property(p => p.Pris)
                .IsRequired();

            this.Property(p => p.Opprettet)
               .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");

           
        }
    }
}