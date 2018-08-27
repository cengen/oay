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
    public class BildegalleriRepository : IRepository<Bildegalleri>
    {

        protected DbSet<Bildegalleri> DbSet { get; set; }
       // protected DbSet<BildegalleriImage> DbSetBildegalleriImages { get; set; }

        protected DbContext Context { get; set; }

        public BildegalleriRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Det må finnes et DbContext" +
                    " objekt for å bruke dette repositoy.", "context");
            }
            this.Context = context;
            this.DbSet = this.Context.Set<Bildegalleri>();
        }

        public virtual IQueryable<Bildegalleri> GetAll()
        {
            return this.DbSet.AsQueryable();
        }

        public IEnumerable<Bildegalleri> GetByBildegalleriId(int bildeid)
        {
            return this.DbSet.Where(m => m.BildegalleriId== bildeid).AsEnumerable();
        }

        public Bildegalleri GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(Bildegalleri entity)
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

        public void Update(Bildegalleri entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(Bildegalleri entity)
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

        public void Detach(Bildegalleri entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        //public BildegalleriImage GetHovedbilde(int id)
        //{
        //    throw new NotImplementedException();
        //}


        //public IEnumerable<BildegalleriImage> GetAllBildegalleriImages()
        //{
        //    throw new NotImplementedException();
        //}

        //public BildegalleriImage GetHovedbilde(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public BildegalleriImage GetHovedbilde()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
