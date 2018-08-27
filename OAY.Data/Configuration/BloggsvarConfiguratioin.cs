using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BloggsvarConfiguration : EntityTypeConfiguration<Bloggsvar>
    {
        public BloggsvarConfiguration()
        {

            this.Property(p => p.BloggsvarId).HasColumnOrder(0);

            this.Property(p => p.BloggpostId)
            .IsRequired();

            this.Property(p => p.BloggsvarNavn)
             .IsRequired();

            this.Property(p => p.BloggsvarInnhold)
                .IsRequired();

            this.Property(p => p.Opprettet)
               .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");
        }
    }
}