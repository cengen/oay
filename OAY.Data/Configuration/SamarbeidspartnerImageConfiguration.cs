using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAY.Models;

namespace OAY.Data.Configuration
{
    public class SamarbeidspartnerImageConfiguration : EntityTypeConfiguration<SamarbeidspartnerImage>
    {
        public SamarbeidspartnerImageConfiguration()
        {

            this.Property(p => p.SamarbeidspartnerImageId).HasColumnOrder(0);

            this.Property(p => p.ImageFile)
            .IsRequired();

            this.Property(p => p.SamarbeidspartnerId)
               .IsRequired();


            this.Property(p => p.Opprettet)
              .IsOptional().HasColumnType("datetime");

            this.Property(p => p.Endret)
               .IsOptional().HasColumnType("datetime");



        }
    }
}