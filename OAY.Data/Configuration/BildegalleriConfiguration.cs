using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BildegalleriConfiguration : EntityTypeConfiguration<Bildegalleri>
    {
        public BildegalleriConfiguration()
        {

            this.Property(p => p.BildegalleriId).HasColumnOrder(0);

            this.Property(p => p.Model)
           .IsRequired();

            this.Property(p => p.Beskrivelse)
         .IsRequired();

            this.Property(p => p.Ingress)
         .IsRequired();

            this.Property(p => p.Tittel)
         .IsRequired();

            this.Property(p => p.Type)
         .IsRequired();



        }
    }
}