using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BloggImageConfiguration : EntityTypeConfiguration<BloggImage>
    {
        public BloggImageConfiguration()
        {

            this.Property(p => p.ImageId).HasColumnOrder(0);

            this.Property(p => p.ImageFile)
            .IsRequired();

            this.Property(p => p.BloggpostId)
                .IsRequired();

            this.Property(p => p.Opprettet)
              .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");
        }
    }
}
