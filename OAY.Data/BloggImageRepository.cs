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
    public class BloggImageRepository : IBloggImageRepository
    {

        protected DbSet<BloggImage> DbSet { get; set; }
        protected DbContext Context { get; set; }

        public BloggImageRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Det må finnes et DbContext" +
                    " objekt for å bruke dette repositoy.", "context");
            }
            this.Context = context;
            this.DbSet = this.Context.Set<BloggImage>();
        }

        public virtual IQueryable<BloggImage> GetAll()
        {
            return this.DbSet.AsQueryable();
        }

        public IEnumerable<BloggImage> GetByBloggpostId(int bloggpostid)
        {
            return this.DbSet.Where(m => m.BloggpostId == bloggpostid).AsEnumerable();
        }

        public BloggImage GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(BloggImage entity)
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

        public void Update(BloggImage entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(BloggImage entity)
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

        public void Detach(BloggImage entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
