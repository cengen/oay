using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using OAY.Models;

//namespace OAY.Data
//{
//    public class SamarbeidspartnerImageRepository : ISamarbeidspartnerImageRepository
//    {

//        //protected DbSet<Samarbeidspartner> DbSet { get; set; }
//        //protected DbContext Context { get; set; }

//        //public SamarbeidspartnerImageRepository(DbContext context)
//        //{
//        //    if (context == null)
//        //    {
//        //        throw new ArgumentException("Det må finnes et DbContext" +
//        //            " objekt for å bruke dette repositoy.", "context");
//        //    }
//        //    this.Context = context;
//        //    this.DbSet = this.Context.Set<Samarbeidspartner>();
//        //}

//        //public  virtual IQueryable<Samarbeidspartner> GetAll()
//        //{
//        //    return this.DbSet.AsQueryable();   //.Include(m => m.SamarbeidspartnerImages).AsQueryable();
//        //}

//        //public IEnumerable<Samarbeidspartner> GetBySamarbeidspartnerId(int id)
//        //{
          
//        //    return this.DbSet.Where(m => m.SamarbeidspartnerId == id).AsEnumerable();
//        //}
////TODO
//        //public SamarbeidspartnerImage GetHovedbilde(int id)
//        //{
//        //    return this.DbSet
//        //        .Where(m => m.SamarbeidspartnerId == id).SingleOrDefault(m => m.ErHovedbilde == true);
//        //}

//        //public SamarbeidspartnerImage GetById(int id)
//        //{
//        //    return this.DbSet.Find(id);
//        //}

//        //public void Add(SamarbeidspartnerImage entity)
//        //{
//        //    DbEntityEntry entry = this.Context.Entry(entity);
//        //    if (entry.State != EntityState.Detached)
//        //    {
//        //        entry.State = EntityState.Added;
//        //    }
//        //    else
//        //    {
//        //        this.DbSet.Add(entity);
//        //    }
//        //}

//        //public void Update(SamarbeidspartnerImage entity)
//        //{
//        //    DbEntityEntry entry = this.Context.Entry(entity);
//        //    if (entry.State == EntityState.Detached)
//        //    {
//        //        this.DbSet.Attach(entity);
//        //    }
//        //    entry.State = EntityState.Modified;
//        //}

//        //public void Delete(SamarbeidspartnerImage entity)
//        //{
//        //    DbEntityEntry entry = this.Context.Entry(entity);
//        //    if (entry.State != EntityState.Deleted)
//        //    {
//        //        entry.State = EntityState.Deleted;
//        //    }
//        //    else
//        //    {
//        //        this.DbSet.Attach(entity);
//        //        this.DbSet.Remove(entity);
//        //    }
//        //}

//        //public void Delete(int id)
//        //{

//        //    var entity = this.GetById(id);
//        //    if (entity != null)
//        //    {
//        //        this.Delete(entity);
//        //    }
//        //}

//        //public void Detach(SamarbeidspartnerImage entity)
//        //{
//        //    DbEntityEntry entry = this.Context.Entry(entity);
//        //    entry.State = EntityState.Detached;
//        //}

//        //IQueryable<SamarbeidspartnerImage> IRepository<SamarbeidspartnerImage>.GetAll()
//        //{
//        //    throw new NotImplementedException();
//        //}
//    }
//}
