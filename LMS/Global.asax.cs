using StudentApp.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Recreates the database when the model changes (good for learning; avoid in production).
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
