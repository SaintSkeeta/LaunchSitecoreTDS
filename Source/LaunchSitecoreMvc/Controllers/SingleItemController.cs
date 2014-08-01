using LaunchSitecore.Configuration.SiteUI.Base;
using LaunchSitecore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.Controllers
{
  public class SingleItemController : LaunchSitecoreBaseController
  {
    public ActionResult AbstractSpot()
    {
      return !IsDataSourceItemNull ? View(new SimpleItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult AbstractBox()
    {
      return !IsDataSourceItemNull ? View(new SimpleItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult FeaturedQuotation()
    {
      return !IsDataSourceItemNull ? View(new QuotationItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult Jumbotron()
    {
      return View(new JumbotronItem(DataSourceItemOrCurrentItem));
    }

    public ActionResult PromoSpotWithNoImage()
    {
      return !IsDataSourceItemNull ? View(new PromoItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult PromoSpotWithImage()
    {
      return !IsDataSourceItemNull ? View(new PromoItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult PromoSpotWithThumbnailImage()
    {
      return !IsDataSourceItemNull ? View(new PromoItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult SmallStickyNote()
    {
      return !IsDataSourceItemNull ? View(new StickyNoteItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult StickyNote()
    {
      return !IsDataSourceItemNull ? View(new StickyNoteItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    public ActionResult TextWidget()
    {
      return !IsDataSourceItemNull ? View(new TextWidgetItem(DataSourceItem)) : ShowNoDataSourcePageEditorAlert();
    }

    private ActionResult ShowNoDataSourcePageEditorAlert()
    {
      return IsPageEditorEditing ? View ("ShowPageEditorAlert", new PageEditorAlert(PageEditorAlert.Alerts.DatasourceIsNull)) : null;
    }
  }
}
