using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BatturImageConfiguration : EntityTypeConfiguration<BatturImage>
    {
        public BatturImageConfiguration()
        {

            this.Property(p => p.ImageId).HasColumnOrder(0);

            this.Property(p => p.ImageFile)
            .IsRequired();

            this.Property(p => p.BatturId)
               .IsRequired();

            this.Property(p => p.ErHovedbilde)
               .IsRequired();


            this.Property(p => p.Opprettet)
              .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");

 

        }
    }
}
