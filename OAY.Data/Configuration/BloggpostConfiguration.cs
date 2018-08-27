using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BloggpostConfiguration : EntityTypeConfiguration<Bloggpost>
    {
        public BloggpostConfiguration()
        {
            this.Property(p => p.BloggpostId).HasColumnOrder(0);

            this.Property(p => p.BloggpostOverskrift)
                .IsRequired();

            this.Property(p => p.BloggpostInnhold)
                .IsRequired();

            this.Property(p => p.Opprettet)
               .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");
        }
    }
}