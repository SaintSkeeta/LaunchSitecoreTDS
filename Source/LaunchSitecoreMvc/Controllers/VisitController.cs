using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using LaunchSitecore.Configuration.SiteUI;
using LaunchSitecore.Models;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.Controllers
{
  public class VisitController : LaunchSitecoreBaseController
  {
    public ActionResult VisitDetails()
    {
      /* Run the query and show the same view as IconAndTitleList */
      //VisitInformation visit = new VisitInformation();
      return Sitecore.Context.PageMode.IsNormal ? View("VisitDetails", new VisitInformation()) : ShowEditorAlert();
    }

    private ActionResult ShowEditorAlert()
    {
      return IsPageEditorEditing ? View("ShowPageEditorAlert", new PageEditorAlert(PageEditorAlert.Alerts.VisitDetailsNotAllowedInPageEditor)) : null;
    }
  }
}
