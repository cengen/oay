using OAY.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAY.Data.Configuration
{
    //public class UserConfiguration : EntityTypeConfiguration<User>
    //{
        //public UserConfiguration()
        //{

        //    this.Property(p => p.Id).HasColumnOrder(0);

        //      this.Property(p => p.UserName)
        //       .IsRequired().HasMaxLength(200);

        //    this.Property(p => p.Email)
        //        .IsOptional();

      


        //    //mapping gjør joining mellom 2 tabeller 
        //    this.HasMany(a => a.Roles)
        //        .WithMany(b => b.Users).Map(m =>
        //            {
        //                m.MapLeftKey("Id");
        //                m.MapRightKey("RoleID");
        //                m.ToTable("webpages_UsersInRoles");
        //            });

        //}
    //}
}

