using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAY.Models;
using System.Data.Entity;

namespace OAY.Data
{
    //For å kunne gjøre endringer i databasen
    //Interface for Repositories
    public class ApplicationUnit : IDisposable
    {
        private DataContext _context = new DataContext();

        private IRepository<Battur> _batturer = null;
        private IRepository<Kategori> _kategorier = null;
        private IBatturImageRepository _batturImages = null;
        private IBloggImageRepository _bloggImages = null;
        private IBatturKategoriRepository _batturKategorier = null;
        private IRepository<Meny> _menyer = null;
        private IRepository<PrisInfo> _prisInfo = null;
        private IRepository<Bildegalleri> _bildegallerier = null;
        private IRepository<Bloggpost> _bloggposter = null;
        private IBloggsvarRepository _bloggsvar = null;
        private IRepository<HvaSkjer> _hvaskjer = null;
        private IRepository<BildegalleriImage> _bildegalleriImages = null;
        private IRepository<Samarbeidspartner> _samarbeidspartnere = null;


        public IRepository<Samarbeidspartner> Samarbeidspartnere
        {
            get
            {
                if (this._samarbeidspartnere == null)
                {
                    this._samarbeidspartnere = new GenericRepository<Samarbeidspartner>(this._context);
                }
                return this._samarbeidspartnere;
            }
        }

        // public ISamarbeidspartnerImageRepository SamarbeidspartnerImages
        //{
        //    get
        //    {
        //        if (this._samarbeidspartnerImages == null)
        //        {
        //            this._samarbeidspartnerImages = new SamarbeidspartnerImageRepository(this._context);
        //        }
        //        return this._samarbeidspartnerImages;
        //    }
        //}
        public IBatturImageRepository BatturImages
        {
            get
            {
                if (this._batturImages == null)
                {
                    this._batturImages = new BatturImageRepository(this._context);
                }
                return this._batturImages;
            }
        }

        public IRepository<BildegalleriImage> BildegalleriImages
        {
            get
            {
                if (this._bildegalleriImages == null)
                {
                    this._bildegalleriImages = new GenericRepository<BildegalleriImage>(this._context);
                }

                return this._bildegalleriImages;
            }
        }

        public IRepository<Bildegalleri> Bildegallerier
        {
            get
            {
                if (this._bildegallerier == null)
                {
                    this._bildegallerier = new GenericRepository<Bildegalleri>(this._context);
                }
                return this._bildegallerier;
            }
        }

        public IRepository<HvaSkjer> HvaSkjer
        {
            get
            {
                if (this._hvaskjer == null)
                {
                    this._hvaskjer = new GenericRepository<HvaSkjer>(this._context); 
                }
                return this._hvaskjer;
            }
        }

        public IRepository<Battur> Batturer
        {
            get
            {
                if (this._batturer == null)
                {
                    this._batturer = new BatturRepository(this._context);
                }
                return this._batturer;
            }
        }

       
        public IRepository<Kategori> Kategorier
        {
            get
            {
                if (this._kategorier == null)
                {
                    this._kategorier = new GenericRepository<Kategori>(this._context); 
                }
                return this._kategorier;
            }
        }

       

        public IBloggImageRepository BloggImages
        {
            get
            {
                if (this._bloggImages == null)
                {
                    this._bloggImages = new BloggImageRepository(this._context);
                }
                return this._bloggImages;
            }
        }


        public IBatturKategoriRepository BatturKategorier
        {
            get
            {
                if (this._batturKategorier == null)
                {
                    this._batturKategorier = new BatturKategoriRepository(this._context);
                }
                return this._batturKategorier;
            }
        }

        public IRepository<Meny> Menyer
        {
            get
            {
                if (this._menyer == null)
                {
                    this._menyer = new GenericRepository<Meny>(this._context);
                }

                return this._menyer;
            }
        }

        public IRepository<PrisInfo> PrisInfo
        {
            get
            {
                if (_prisInfo == null)
                {
                    this._prisInfo = new GenericRepository<PrisInfo>(this._context);
                }

                return this._prisInfo;
            }
        }

       

        public IRepository<Bloggpost> Bloggposter
        {
            get
            {
                if (this._bloggposter == null)
                {
                    this._bloggposter = new GenericRepository<Bloggpost>(this._context);
                }

                return this._bloggposter;
            }
        }

        public IBloggsvarRepository Bloggsvar
        {
            get
            {
                if (this._bloggsvar == null)
                {
                    this._bloggsvar = new BloggsvarRepository(this._context);
                }

                return this._bloggsvar;
            }
        }


       

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

 

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
