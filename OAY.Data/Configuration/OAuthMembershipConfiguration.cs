using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            this.ToTable("webpages_OAuthMembership");

            this.HasKey(k =>
                new { k.Provider, k.ProviderId });

            this.Property(p => p.Provider)
                .HasColumnType("nvarchar")
                .HasMaxLength(30).IsRequired();

            this.Property(p => p.ProviderId)
                .HasColumnType("nvarchar")
                .HasMaxLength(30).IsRequired();

            this.Property(p => p.ProviderId)
                .HasColumnType("nvarchar")
                .HasMaxLength(100).IsRequired();

            this.Property(p => p.Id).IsRequired();
        }
    }
}
