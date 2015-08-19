using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI;
using LaunchSitecore.Models;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;

namespace LaunchSitecore.Controllers
{
  public class ListsController : LaunchSitecoreBaseController
  {
    public ActionResult ArticlesByContributor()
    {
      if (Sitecore.Context.Item.Template.Key != "team member") return null;
      
      // this query will get the articles by the current team member
      // The queried list can also handle this by setting the datasource to a query.
      // The Standard Values can even pass in the id when the item is created.  
      // Example Query: +template:d9019e30f95446ccaa703e928c40b5d0;+location:63ABEE8A4E3841599193D5F0A33AD666;+custom:contributors|$id;
      string query = String.Format("+custom:contributors|{0};+template:d9019e30f95446ccaa703e928c40b5d0;+location:63ABEE8A4E3841599193D5F0A33AD666;", Sitecore.Context.Item.ID.ToString());
      List<SimpleItem> items = new List<SimpleItem>();
      foreach (Item i in GetDataSourceItemsFromQuery(query)) items.Add(new SimpleItem(i));
      SimpleItemList results = new SimpleItemList(SiteConfiguration.GetDictionaryText("Articles"), items);
      return !items.IsNullOrEmpty() ? View("LinkList", results) : ShowListIsEmptyPageEditorAlert();
    }

    public ActionResult Carousel()
    {
        /* Use the base class to get the results of the query */
        if (IsDataSourceItemNull) return ShowListIsEmptyPageEditorAlert();

        IEnumerable<CarouselItem> items = new CarouselItem(DataSourceItem).ChildrenInCurrentLanguage;
        return !items.IsNullOrEmpty() ? View(items) : ShowListIsEmptyPageEditorAlert();
    }

    public ActionResult IconAndTitleList()
    {
      /* Populate with: Children of Datasource OR Children of Current */
      IEnumerable<SimpleItem> items = new SimpleItem(DataSourceItemOrCurrentItem).ChildrenInCurrentLanguage;
      return !items.IsNullOrEmpty() ? View(items) : ShowListIsEmptyPageEditorAlert();      
    }

    public ActionResult LinkList()
    {
        /* make sure the datasource or current has children in the current language and render accordingly */
        IEnumerable<SimpleItem> items = new SimpleItem(DataSourceItemOrCurrentItem).ChildrenInCurrentLanguage;
        SimpleItemList results = new SimpleItemList(DataSourceItem["Menu Title"], items);
        return !items.IsNullOrEmpty() ? View(results) : ShowListIsEmptyPageEditorAlert();
    }

    public ActionResult IconAndTitleListForQuery()
    {
      /* Run the query and show the same view as IconAndTitleList */
      IEnumerable<SimpleItem> items = DataSourceItems.Select(x => new SimpleItem(x)).Where(x => SiteConfiguration.DoesItemExistInCurrentLanguage(x.Item));
      return !items.IsNullOrEmpty() ? View("IconAndTitleList", items) : ShowListIsEmptyPageEditorAlert();
    }
      
    public ActionResult QueriedList()
    {
      if (IsDataSourceItemNull) return null;

      IEnumerable<SimpleItem> items = DataSourceItems.Select(x => new SimpleItem(x)).Where(x => SiteConfiguration.DoesItemExistInCurrentLanguage(x.Item));
      SimpleItemList results = new SimpleItemList(DataSourceItem["Title"], items);
      return !items.IsNullOrEmpty() ? View("LinkList", results) : ShowListIsEmptyPageEditorAlert();
    }

    public ActionResult RelatedArticles()
    {
      /* make sure the datasource or current has children in the current language and render accordingly */
      List<SimpleItem> items = new List<SimpleItem>();

      //first get items related to me...
      MultilistField related = Sitecore.Context.Item.Fields["Prerequisite Articles"];
      if (related != null)
        foreach (Item i in related.GetItems()) { if (SiteConfiguration.DoesItemExistInCurrentLanguage(i)) items.Add(new SimpleItem(i)); }

      //now get items I am related to
      foreach (Item i in Sitecore.Context.Database.SelectItems(SiteConfiguration.GetFurtherReadingArticlesQuery(Sitecore.Context.Item.ID.ToString())))
      {
        if (SiteConfiguration.DoesItemExistInCurrentLanguage(i)) items.Add(new SimpleItem(i));
      }

      SimpleItemList results = new SimpleItemList(SiteConfiguration.GetDictionaryText("Related Articles"), items);
      return !items.IsNullOrEmpty() ? View("LinkList", results) : ShowListIsEmptyPageEditorAlert();
    }

    public ActionResult Tags()
    {
      List<SimpleItem> items = new List<SimpleItem>();
      MultilistField tags = Sitecore.Context.Item.Fields["__semantics"];
      if (tags != null && tags.GetItems().Length > 0)
      {
        foreach (Item i in tags.GetItems()) items.Add(new SimpleItem(i));
      }
      return !items.IsNullOrEmpty() ? View(items) : ShowItemNotTaggedPageEditorAlert();
    }

    public ActionResult TeamList()
    {
      /* Populate with: Children of Datasource OR Children of Current */
      Item team = SiteConfiguration.GetTeamItem();
      if (team != null && team.Template.Key == "team section") 
      {
        IEnumerable<SimpleItem> items = new SimpleItem(DataSourceItemOrCurrentItem).ChildrenInCurrentLanguage;
        return !items.IsNullOrEmpty() ? View(items) : null;        
      }      
      return null;
    }

    private ActionResult ShowListIsEmptyPageEditorAlert()
    {
      return IsPageEditorEditing ? View("ShowPageEditorAlert", new PageEditorAlert(PageEditorAlert.Alerts.ListIsEmpty)) : null;
    }

    private ActionResult ShowItemNotTaggedPageEditorAlert()
    {
      return IsPageEditorEditing ? View("ShowPageEditorAlert", new PageEditorAlert(PageEditorAlert.Alerts.ItemIsNotTagged)) : null;
    }
  }
}
