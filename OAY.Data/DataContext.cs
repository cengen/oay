using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using OAY.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using OAY.Data.Configuration;



namespace OAY.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(nameOrConnectionString: DataContext.ConnectionStringName) { 

       this.Configuration.LazyLoadingEnabled = false; 
       this.Configuration.ProxyCreationEnabled = false; 
    }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Battur> Batturer { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<BatturKategori> BatturKategorier { get; set; }
        public DbSet<BatturImage> BatturImages { get; set; }
        public DbSet<BloggImage> BloggImages { get; set; }
        public DbSet<Meny> Meny { get; set; }
        public DbSet<PrisInfo> Priser { get; set; }
        public DbSet<BildegalleriImage> Bildegallerier { get; set; }
        public DbSet<Bildegalleri> Bildegalleri { get; set; }
        public DbSet<Bloggpost> Bloggposter { get; set; }
        public DbSet<Bloggsvar> Bloggsvar { get; set; }
        public DbSet<HvaSkjer> HvasKjer { get; set; }
        public DbSet<Samarbeidspartner> Samarbeidspartnere { get; set; }
        public DbSet<SamarbeidspartnerImage> SamarbeidspartnerImages { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ikke sett +s på tabellnavn
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BatturConfiguration());
            modelBuilder.Configurations.Add(new KategoriConfiguration());
            modelBuilder.Configurations.Add(new BatturKategoriConfiguration());
            modelBuilder.Configurations.Add(new BatturImageConfiguration());
            modelBuilder.Configurations.Add(new BloggImageConfiguration());
            modelBuilder.Configurations.Add(new MenyConfiguration());
            modelBuilder.Configurations.Add(new PrisConfiguration());
            modelBuilder.Configurations.Add(new BildegalleriImageConfiguration());
            modelBuilder.Configurations.Add(new BildegalleriConfiguration());
            modelBuilder.Configurations.Add(new BloggpostConfiguration());
            modelBuilder.Configurations.Add(new BloggsvarConfiguration());
            modelBuilder.Configurations.Add(new HvaSkjerConfiguration());
            modelBuilder.Configurations.Add(new SamarbeidspartnerConfiguration());
            modelBuilder.Configurations.Add(new SamarbeidspartnerImageConfiguration());
        }



        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());

        }

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "OAAzureDEV";
            }
        }

        //om det er en endring av en entitet så settes modified
        //NB! husk å legge inn i SaveChanges()
        private void ApplyRules()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(
                e => e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added) ||
                    (e.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    e.Opprettet = DateTime.Now;
                }
                e.Endret = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyRules();
            return base.SaveChanges();
        }

    }
}
