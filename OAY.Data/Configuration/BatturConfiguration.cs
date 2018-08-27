using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    public class BatturConfiguration : EntityTypeConfiguration<Battur>
    {
        public BatturConfiguration()
        {

            this.Property(p => p.BatturId).HasColumnOrder(0);

            this.Property(p => p.FraSted)
                .IsOptional().HasMaxLength(100);

            this.Property(p => p.TilSted)
                .IsRequired().HasMaxLength(100);

            this.Property(p => p.MinimumTid)
                .IsRequired();

            this.Property(p => p.Pris)
                .IsOptional();

            this.Property(p => p.Overskrift)
                .IsRequired();

            this.Property(p => p.Ingress)
                .IsRequired();

            this.Property(p => p.Beskrivelse)
                .IsRequired();

            this.Property(p => p.EngelskBeskrivelse)
               .IsRequired();

            this.Property(p => p.Opprettet)
                .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");
        }
    }
}