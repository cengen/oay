using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class PrisConfiguration : EntityTypeConfiguration<PrisInfo>
    {
        public PrisConfiguration()
        {

            this.Property(p => p.PrisInfoId).HasColumnOrder(0);

            this.Property(p => p.Timepris)
              .IsRequired();

            this.Property(p => p.ImageFile)
             .IsRequired();

           

           
        }
    }
}