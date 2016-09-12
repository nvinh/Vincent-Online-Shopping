using OnlineShop3.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop3.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //initilizing culture on controller initialization - Select language
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session[CommonConstants.CurrentCulture] !=null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
            }
            else
            {
                Session[CommonConstants.CurrentCulture] = "en";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");    //default language is English
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
        }
        //changing culture - change language
        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);
            Session[CommonConstants.CurrentCulture] = ddlCulture;
            return Redirect(returnUrl);
        }


        // check Login for Admin area
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.User_Session];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller="Login",action="Index",Area="Admin"}));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message; // Get data from server by using provided TempData class
            if (type=="success")
            {
                TempData["AlertType"] = "alert-success";
            } else if (type=="warning")
            {
                TempData["AlertType"] = "alert-warning";
            } else if (type=="error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}