﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAY.Models;

namespace OAY.Data
{
    //public class BildegalleriImageRepository : IBildegalleriImageRepository
    //{

    //    protected DbSet<BildegalleriImage> DbSet { get; set; }
    //    protected DbContext Context { get; set; }

    //    public BildegalleriImageRepository(DbContext context)
    //    {
    //        if (context == null)
    //        {
    //            throw new ArgumentException("Det må finnes et DbContext" +
    //                " objekt for å bruke dette repositoy.", "context");
    //        }
    //        this.Context = context;
    //        this.DbSet = this.Context.Set<BildegalleriImage>();
    //    }

    //    public IQueryable<BildegalleriImage> GetAll()
    //    {
    //        return this.DbSet;   //.Include(m => m.BatturImages).AsQueryable();
    //    }

    //    public IEnumerable<BildegalleriImage> GetByBatturId(int d)
    //    {
    //        return this.DbSet.Where(m => m.BildeId == id).AsEnumerable();
    //    }
    //    //TODO
    //    public BildegalleriImage GetHovedbilde()
    //    {
    //        return this.DbSet.Where(m => m.BatturId == batturid).Where(m => m.ErHovedbilde == true).SingleOrDefault();
    //    }

    //    public BatturImage GetById(int id)
    //    {
    //        return this.DbSet.Find(id);
    //    }

    //    public void Add(BatturImage entity)
    //    {
    //        DbEntityEntry entry = this.Context.Entry(entity);
    //        if (entry.State != EntityState.Detached)
    //        {
    //            entry.State = EntityState.Added;
    //        }
    //        else
    //        {
    //            this.DbSet.Add(entity);
    //        }
    //    }

    //    public void Update(BatturImage entity)
    //    {
    //        DbEntityEntry entry = this.Context.Entry(entity);
    //        if (entry.State == EntityState.Detached)
    //        {
    //            this.DbSet.Attach(entity);
    //        }
    //        entry.State = EntityState.Modified;
    //    }

    //    public void Delete(BatturImage entity)
    //    {
    //        DbEntityEntry entry = this.Context.Entry(entity);
    //        if (entry.State != EntityState.Deleted)
    //        {
    //            entry.State = EntityState.Deleted;
    //        }
    //        else
    //        {
    //            this.DbSet.Attach(entity);
    //            this.DbSet.Remove(entity);
    //        }
    //    }

    //    public void Delete(int id)
    //    {

    //        var entity = this.GetById(id);
    //        if (entity != null)
    //        {
    //            this.Delete(entity);
    //        }
    //    }

    //    public void Detach(BatturImage entity)
    //    {
    //        DbEntityEntry entry = this.Context.Entry(entity);
    //        entry.State = EntityState.Detached;
    //    }
    //}
}