using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using LaunchSitecore.Models;
using LaunchSitecore.Configuration.SiteUI.Analytics;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.SiteUI.Base;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.Controllers
{
  public class SearchController : LaunchSitecoreBaseController
  {
    [HttpGet]
    public ActionResult Search(string searchStr, string tag)
    {
      return View(new SearchResults("*", new string[] { String.Format("{0}|{1}", SiteConfiguration.GetDictionaryText("Tags"), tag) }));
    }

    [HttpPost]
    public ActionResult Search(string searchStr, string[] facets)
    {
      return View(new SearchResults(searchStr, facets));
    }
  }
}
