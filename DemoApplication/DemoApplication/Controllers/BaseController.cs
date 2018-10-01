using Demo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApplication.Web
{
    public class BaseController : Controller
    {
        private ILog _ILog;

        public BaseController()
        {
            _ILog = ErrorLog.GetInstance;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.WriteLogInServer(filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
        }
    }
}