using System;
using Sitecore.Data;
using Sitecore.Mvc.Pipelines.MvcEvents.Exception;
using System.Web.Mvc;
using System.Web;

namespace LaunchSitecore.Configuration.Events.mvc.exception
{
    public class ShowLaunchSitecoreErrorMessage : ShowAspNetErrorMessage
    {
        protected override bool ShowErrorMessage(ExceptionContext exceptionContext, ExceptionArgs args)
        {
            if (this.GetResponse(args) == null || Sitecore.Context.RawUrl.StartsWith("/sitecore/"))
                return false;
            else
            {
                // if the error page threw the error, do not handle it.
                if (args.PageContext.Item.TemplateID == new ID("{455B0CD7-43EE-4553-A7AD-FFFC1DA2143E}")) 
                    return false;

                HttpContext.Current.Session["Last Exception"] = exceptionContext.Exception;
                HttpContext.Current.Response.Redirect("/error", true); 
                return true;
            }
        }
    }
}