using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.Controllers
{
  public class MetaController : LaunchSitecoreBaseController
  {
    public string CssTheme()
    {
      Item pres = SiteConfiguration.GetPresentationSettingsItem();
      if (pres != null)
        return String.Format("<link rel=\"stylesheet\" href=\"/assets/css/colors/color_scheme_{0}.css\" />", pres.Fields["Site Color"].Value.ToLower());
      return null;
    }

    public string PageTitle()
    {
      Item siteSettings = SiteConfiguration.GetSiteSettingsItem();
      Item home = SiteConfiguration.GetHomeItem();
      Item currentItem = Sitecore.Context.Item;

      if (Sitecore.Context.Item.ID == home.ID || Sitecore.Context.Item.ParentID == home.ID)
      {
        return String.Format(siteSettings["Page Title for Home and Site Sections"], currentItem["Menu Title"]);
      }
      else
      {
        Item section = currentItem.Parent;
        while (section.ParentID != home.ID)
        {
          section = section.Parent;
        }
        return String.Format(siteSettings["Page Title for Lower Pages"], currentItem["Menu Title"], section["Menu Title"]);
      }
    }

    public string MetaTags()
    {
      // http://www.seomoz.org/blog/the-wonderful-world-of-seo-metatags
      return String.Format("<meta name=\"title\" content=\"{0}\" /><meta name=\"description\" content=\"{1}\" />", Sitecore.Context.Item["Menu Title"], SiteConfiguration.GetPageDescripton(Sitecore.Context.Item));     
    }
  }
}
