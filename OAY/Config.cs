using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace OAY.Web
{
    //NB! Sett alle disse statiske verdiene i web.config filens <appSettings>
    //og endre i InitializeSimpleMembershipAttribute
    public class Config
    {
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

        public static string UserTableName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UserTableName"] != null)
                {
                    return ConfigurationManager.AppSettings["UserTableName"].ToString();
                }
                return "User";
            }
        }

        public static string UserPrimaryKeyColumnName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UserPrimaryKeyColumnName"] != null)
                {
                    return ConfigurationManager.AppSettings["UserPrimaryKeyColumnName"].ToString();
                }
                return "Id";
            }
        }

        public static string UsersUserNameColumnName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersUserNameColumnName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersUserNameColumnName"].ToString();
                }
                return "UserName";
            }
        }

        public static string SamarbeidspartnerImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["SamarbeidspaartnerImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["SamarbeidspartnerImagesFolderPath"].ToString();
                }
                return "~/Images/Samarbeidspartnere/";
            }
        }

        public static string PrisImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["PrisImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["PrisImagesFolderPath"].ToString();
                }
                return "~/Images/Pris/";
            }
        }

        public static string BildegalleriImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["BildegalleriImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["BildegalleriImagesFolderPath"].ToString();
                }
                return "~/Images/Bildegalleri/";
            }
        }


        public static string BatturerImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["BatturerImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["BatturerImagesFolderPath"].ToString();
                }
                return "~/Images/Batturer/";
            }
        }

        public static string BloggerImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["BloggerImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["BloggerImagesFolderPath"].ToString();
                }
                return "~/Images/Blogg/";
            }
        }


        //public static string BloggImagesFolderPath
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["BloggImagesFolderPath"] != null)
        //        {
        //            return ConfigurationManager.AppSettings["BloggImagesFolderPath"].ToString();
        //        }
        //        return "~/Images/Blogg/";
        //    }
        //}


        public static string ImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["ImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["ImagesFolderPath"].ToString();
                }
                return "~/Images/";
            }
        }

        //brukes ved opplasting av bilder. 
        public static string UrlPrefix
        {
            get { return Config.ImagesFolderPath.Replace("~", ""); }
        }

 

        //brukes ved opplasting av bilder. 
        public static string BatturerImagesUrlPrefix
        {
            get { return Config.BatturerImagesFolderPath.Replace("~", ""); }
        }

        public static string ImagesUrlPrefix
        {
            get { return Config.ImagesFolderPath.Replace("~", ""); }
        }

        public static string BloggpostImagesUrlPrefix
        {
            get { return Config.BloggerImagesFolderPath.Replace("~", ""); }
        }

        public static string SamarbeidspartnerImagesUrlPrefix
        {
            get { return Config.SamarbeidspartnerImagesFolderPath.Replace("~", ""); }
        }

        public static string PrisInfoImagesUrlPrefix
        {
            get { return PrisImagesFolderPath.Replace("~", ""); }
        }
        public static string BildegalleriImagesUrlPrefix
        {
            get { return BildegalleriImagesFolderPath.Replace("~", ""); }
        }




        public static string BloggerImagesUrlPrefix
        {
            get { return Config.BloggerImagesFolderPath.Replace("~", ""); }
        }


        public static string SeoName(string name)
        {
            return Regex.Replace(name.ToLower().Replace(@"'", String.Empty), @"[^\w]+", "-");
        }


        public static int Timepris
        {
            get { return 3600; }
        }

        public static int Minimumstid
        {
            get { return 3; }
        }
    }
}
