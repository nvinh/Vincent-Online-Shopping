using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
//using OnlineShop3.Common;

namespace OnlineShop3
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized)
            //{
            //    return false;
            //}
            var session = (Common.UserLogin)HttpContext.Current.Session[Common.CommonConstants.User_Session];
            if(session==null)
            {
                return false;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserName);

            if (privilegeLevels.Contains(this.RoleID) || session.UserGroupID== CommonConstants.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }

            //return base.AuthorizeCore(httpContext);
        }

        // this procedure is used for redirect the Unauthorized page to a custom page
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
            //base.HandleUnauthorizedRequest(filterContext);
        }

        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var credentials= (List<string>)HttpContext.Current.Session[Common.CommonConstants.Session_Credentials];
            return credentials;
        }
    }
}