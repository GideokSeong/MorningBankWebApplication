using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MorningBank
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            string cookieName = FormsAuthentication.FormsCookieName;

            HttpCookie authCookie = Context.Request.Cookies[cookieName];

            if (null == authCookie)
            {
                return;  // There is no authentication cookie. 
            }
            FormsAuthenticationTicket authTicket = null;

            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception)
            {
                return; // Log exception details (omitted for simplicity) 
            }
            if (null == authTicket)
                return;  // Cookie failed to decrypt. 

            // When the ticket was created, the UserData property was assigned             
            // a pipe delimited string of role names.             
            string roles = authTicket.UserData;
            string[] roleListArray = roles.Split(new char[] { '|' });
            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, roleListArray);
        }
    }
}
