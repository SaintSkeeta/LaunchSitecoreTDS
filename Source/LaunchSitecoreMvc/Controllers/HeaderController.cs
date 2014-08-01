using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using LaunchSitecore.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.Controllers
{
  public class HeaderController : LaunchSitecoreBaseController
  {
    public ActionResult Header()
    {
      // This page is setting a lot fo the presentation details.  This is due tot he flexible nature of this site.
      Item presentationSettings = SiteConfiguration.GetPresentationSettingsItem();
      if (presentationSettings != null)
      {
        return (presentationSettings["Logo Location"] == "Header") ? View("HeaderWithLogo", presentationSettings) : View("HeaderWithoutLogo");
      }
      return null;
    }

    /* The theme for Launch Sitecore includes a few attributes to enable variations within the site. These methods support this. */
    public string BodyClass()
    {
      Item pres = SiteConfiguration.GetPresentationSettingsItem();
      if (pres != null && pres["Background Image"] != string.Empty)
      {        
        ImageField imgField = ((Sitecore.Data.Fields.ImageField)pres.Fields["Background Image"]);
        return imgField.MediaItem.Parent.Key == "patterns" ? "background-pattern" : "background-cover";        
      }
      return null;
    }

    public string BodyStyle()
    {      
      Item pres = SiteConfiguration.GetPresentationSettingsItem();
      if (pres != null)
      {
        if (pres["Background Image"] != string.Empty)
        {
          ImageField imgField = ((Sitecore.Data.Fields.ImageField) pres.Fields["Background Image"]);
          return String.Format("background-image: url('{0}')", MediaManager.GetMediaUrl(imgField.MediaItem));          
        }
        else if (pres["Background Color"] != string.Empty)
        {
          return String.Format("background-color: {0}", pres["Background Color"]);
        }
      }
      return null;
    }

    public string TopLineClass()
    {
      Item pres = SiteConfiguration.GetPresentationSettingsItem();
      if (pres != null)
        return pres["Show Top Line"] == "1" ? "top_line" : "top_line_plain";
      return "top_line";
    }

    public string PageLayoutClass()
    {
      Item pres = SiteConfiguration.GetPresentationSettingsItem();
      if (pres != null)
        return pres["Layout Style"].ToLower().Replace(" ", "-");
      return null;
    }
  }
}
