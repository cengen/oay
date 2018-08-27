using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAY.Models;

namespace OAY.Data.Configuration
{
    public class SamarbeidspartnerConfiguration : EntityTypeConfiguration<Samarbeidspartner>
    {
        public SamarbeidspartnerConfiguration()
        {
            this.Property(p => p.SamarbeidspartnerId)
                .HasColumnOrder(0);

            this.Property(p => p.AntallPersoner)
                .IsOptional();
            this.Property(p => p.Merke )
               .IsOptional();
            this.Property(p => p.Ingress)
               .IsOptional();
            this.Property(p => p.Overskrift)
               .IsRequired();
            this.Property(p => p.Beskrivelse)
                .IsRequired();
            this.Property(p => p.Logo)
               .IsOptional();
            this.Property(p => p.Link)
              .IsOptional();
            this.Property(p => p.Opprettet)
               .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");
            
        }
    }
}

