using Demo.Service;
using Demo.Service.DBContext;
using DemoApplication.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;

namespace DemoApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer objContainer = new UnityContainer();
            objContainer.RegisterType<IStudentService, StudentService>().RegisterType<IDemoContext, DemoContext>();
            //objContainer.Resolve<IStudentService>();
            DependencyResolver.SetResolver(new DemoDependencyResolver(objContainer));
        }
    }
}
