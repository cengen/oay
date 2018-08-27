using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class HvaSkjerConfiguration : EntityTypeConfiguration<HvaSkjer>
    {
        public HvaSkjerConfiguration()
        {
         
            this.Property(p => p.HvaSkjerId).HasColumnOrder(0);

            this.Property(p => p.Overskrift)
                 .IsRequired();

            this.Property(p => p.Innhold)
                .IsRequired();

            this.Property(p => p.Dag)
                .IsRequired();

             this.Property(p => p.Mnd)
                .IsRequired();

             this.Property(p => p.Link)
                .IsOptional();


            this.Property(p => p.Opprettet)
              .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");


        }
    }
}
