using System.Linq;
using OAY.Models;
using System.Collections.Generic;

namespace OAY.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Detach(T entity);

    }

    public interface IBatturImageRepository : IRepository<BatturImage>
    {
        IEnumerable<BatturImage> GetByBatturId(int batturid);
        BatturImage GetHovedbilde(int batturid);
    }

    public interface ISamarbeidspartnerImageRepository : IRepository<SamarbeidspartnerImage>
    {
        IEnumerable<Samarbeidspartner> GetBySamarbeidspartnerId(int samarbeidspartnerid);
        SamarbeidspartnerImage GetHovedbilde(int samarbeidspartnerid);
    }

    public interface IBloggImageRepository : IRepository<BloggImage>
    {
        IEnumerable<BloggImage> GetByBloggpostId(int bloggpostid);
    }

    public interface IBildegalleriImageRepository : IRepository<BildegalleriImage>
    {
      //  IEnumerable<BildegalleriImage> GetAllBildegalleriImages();
        BildegalleriImage GetHovedbilde(int id);
    }

    public interface IPrisRepository : IRepository<PrisInfo>
    {
        IEnumerable<PrisInfo> GetByPrisId(int prisid);
    }

    public interface IBatturKategoriRepository : IRepository<BatturKategori>
    {
        List<BatturKategori> GetByBatturId(int batturid);
    }

      public interface IBloggsvarRepository : IRepository<Bloggsvar>
    {
          IEnumerable<Bloggsvar> GetByBloggpostId(int bloggpostid);
    }

     
   
}
