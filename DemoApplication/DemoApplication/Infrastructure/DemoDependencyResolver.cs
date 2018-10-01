using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace DemoApplication.Web
{
    public class DemoDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _objContainer;

        public DemoDependencyResolver(IUnityContainer Container)
        {
            _objContainer = Container;
        }

        object IDependencyResolver.GetService(Type serviceType)
        {
            try
            {
                return _objContainer.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            try
            {
                return _objContainer.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }
    }
}