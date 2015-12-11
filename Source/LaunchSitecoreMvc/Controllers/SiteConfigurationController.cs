using System.Runtime.CompilerServices;
using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI;
using LaunchSitecore.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Shell.Applications.ContentEditor;

namespace LaunchSitecore.Controllers
{
  public class SiteConfigurationController : LaunchSitecoreBaseController
  {
    public string CssColor()
    {
        /* This solution allows us to quickly change the color of the links and buttons (at run-time) by generating an
         * on page style tag.  In a production system, you typically would load a different css file to change the theme.  
         * The benefit of our solution is that it allows the addition of any color simply by adding a Sitecore item. */
        string defaultColor = "#008998";
        string newColor = GetColor("Site Color");
        string css = System.IO.File.ReadAllText(Server.MapPath("/assets/css/color.css"));
        return string.Format("<style type=\"text/css\">{0}</style>", css.Replace(defaultColor, newColor));
    }

    private string GetColor(string fieldName)
    {
        Item pres = SiteConfiguration.GetSiteConfigurationItem();
        if (pres != null)
        {
            Sitecore.Data.Database d = Sitecore.Context.ContentDatabase ?? Sitecore.Context.Database;
            Item i = d.GetItem(pres[fieldName]);
            if (i != null) return i["Color Value"];
        }
        return null;
    }

    public string BackgroundColor()
    {
        if (PageLayoutClass() != null && PageLayoutClass() == "boxed") 
            return GetColor("Background Color");
        return null;
    }

    public string HeaderColor()
    {
        return GetColor("Header Color");
    }

    public string MenuColor()
    {
        return GetColor("Menu Color");
    }

    public string FooterColor()
    {
        return GetColor("Footer Color");
    }

    public string CopyrightBackgroundColor()
    {
        return GetColor("Copyright Background Color");
    }

    public string TopLineClass()
    {
     Item pres = SiteConfiguration.GetSiteConfigurationItem();
      if (pres != null)
        return pres["Show Top Line"] == "1" ? "top_line" : "top_line_plain";
      return "top_line";
    }

    public string PageLayoutClass()
    {
     Item pres = SiteConfiguration.GetSiteConfigurationItem();
      if (pres != null)
        return pres["Layout Style"].ToLower().Replace(" ", "-");
      return null;
    }
  }
}
