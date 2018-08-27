using OAY.Models;
using System.Data.Entity;

namespace OAY.Data
{
    public class KategoriRepository : GenericRepository<Kategori>
    {
        public KategoriRepository(DbContext context) :
            base(context) { }
    }
}
