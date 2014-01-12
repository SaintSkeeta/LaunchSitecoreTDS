using System;
using System.Web;
using System.Web.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace LaunchSitecore
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            #if DEBUG
                return;
            #else
            
                HttpException lastException = Server.GetLastError() as HttpException;
                
                if (lastException != null)
                {
                    Log.Error("[Application_Error] UNHANDLED EXCEPTION", this);
                    Log.Error("[Application_Error] " + lastException.StackTrace, this);

                    Server.ClearError();

                    //Redirects to friendly error page, if there is any unhandled exceptions
                    ID errorPageItemId = new ID("{98403172-3C23-44D6-B38D-7A438E18E4FD}");
                    Item errorPageItem = Sitecore.Context.Database.GetItem(errorPageItemId);
                    string errorPageItemUrl = GeneralHelper.GetItemUrl(errorPageItem);

                    Response.Redirect(errorPageItemUrl, false);
                }

            #endif
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
		
        public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
        {
            string frameworkVersion = this.GetFrameworkVersion();
            if (!string.IsNullOrEmpty(frameworkVersion) && frameworkVersion.StartsWith("v4.", StringComparison.InvariantCultureIgnoreCase))
            {
                args.User = Sitecore.Context.User;
            }
        }

        string GetFrameworkVersion()
        {
            try
            {
                return System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
            }
            catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Cannot get framework version", ex, this);
                return string.Empty;
            }
        }
    }
}