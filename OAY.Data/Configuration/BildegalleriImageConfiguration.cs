using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BildegalleriImageConfiguration : EntityTypeConfiguration<BildegalleriImage>
    {
        public BildegalleriImageConfiguration()
        {

            this.Property(p => p.BildeId).HasColumnOrder(0);

            this.Property(p => p.ImageFile)
           .IsRequired();

            this.Property(p => p.ErHovedbilde)
             .IsRequired();


        }
    }
}