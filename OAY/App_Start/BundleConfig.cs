using System.Web;
using System.Web.Optimization;



namespace OAY.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
     

             bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/lib/jquery-1.9.1.min.js",
                        "~/Scripts/lib/bootstrap.min.js",
                        "~/Scripts/lib/knockout-3.3.0.min.js",
                        "~/Scripts/lib/underscore.min.js",
                        "~/Scripts/lib/moment.min.js",
                         "~/Scripts/app/main.min.js"                                               
                        ));


            //brukes til login/registrering av brukere
             bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/lib/jquery.validate.min.js",
                         "~/Scripts/lib/jquery.unobtrusive-ajax.min.js",
                         "~/Scripts/lib/jquery.validate.unobtrusive.min.js"
                         ));
      

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr.custom.48287.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Fonts/font-awesome/css/font-awesome.css",
                "~/Content/css/bootstrap-style.min.css"));

    
        }
    }
}