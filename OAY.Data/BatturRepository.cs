using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAY.Models;

namespace OAY.Data
{
    public class BatturRepository : IRepository<Battur>
    {
        
        protected DbSet<Battur> DbSet { get; set; }
        protected DbContext Context { get; set; }

        public BatturRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Det må finnes et DbContext" +
                    " objekt for å bruke dette repositoy.", "context");
            }
            this.Context = context;
            this.DbSet = this.Context.Set<Battur>();
        }

        public virtual IQueryable<Battur> GetAll()
        {
            return this.DbSet
               //.Include(k => k.BatturKategorier.Select(b => b.Kategori)).ToList()
                .AsQueryable();
        }

        public virtual Battur GetById(int id)
        {
            return this.DbSet
               // .Include(k => k.BatturKategorier.Select(b => b.Kategori))
                .SingleOrDefault(x => x.BatturId == id);

        }

        public void Add(Battur entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public void Update(Battur entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(Battur entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {

            var entity = this.GetById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Detach(Battur entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
