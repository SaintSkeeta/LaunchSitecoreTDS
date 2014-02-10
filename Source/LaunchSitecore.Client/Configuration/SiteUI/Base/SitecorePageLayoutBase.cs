using System.Web.UI.WebControls;
using LaunchSitecore.Configuration.AuthoringExperience.PageEditor;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using Sitecore.ContentSearch;
using System.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Buckets.Util;
using System.Collections.Generic;

namespace LaunchSitecore.Configuration.SiteUI.Base
{
  public class SitecorePageLayoutBase : System.Web.UI.Page
  {

    // Page level error handling can easily be configured in the web.config.  Since this site runs on a clean install of Sitecore, we are handling it here.
    private void Page_Error(object sender, EventArgs e)
    {
      if (Request.Url.AbsolutePath != "/error")
      {       
        Session["LastException"] = Server.GetLastError();
        Response.Redirect("/error", true);        
      }
      else
      {
        // Pass the error on to the default global handler
      }
    }
  }
}