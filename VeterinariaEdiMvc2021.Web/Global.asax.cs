using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VeterinariaEdiMvc2021.Web.App_Start;

namespace VeterinariaEdiMvc2021.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Init();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
