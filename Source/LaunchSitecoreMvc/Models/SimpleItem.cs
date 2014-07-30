using LaunchSitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Models
{
  public class SimpleItem : CustomItem
  {
    public SimpleItem(Item item) : base(item)
    {
      Assert.IsNotNull(item, "item");      
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string MenuTitle
    {
      get { return InnerItem[FieldId.MenuTitle]; }
    }

    public string Abstract
    {
      get { return InnerItem[FieldId.Abstract]; }
    }

    public string Body
    {
      get { return InnerItem[FieldId.Body]; }
    }

    public string ItemIcon
    {
      get { return InnerItem[FieldId.Icon]; }
    }

    public string Url
    {
      get { return LinkManager.GetItemUrl(InnerItem); }
    }

    public string SearchDescription
    {
      get { return SiteConfiguration.GetPageDescripton(Item); }
    }

    public Item Item
    {
      get { return InnerItem; }
    }

    public IEnumerable<SimpleItem> ChildrenInCurrentLanguage
    {
      get
      {
        return InnerItem.Children.Select(x => new SimpleItem(x)).Where(x => SiteConfiguration.DoesItemExistInCurrentLanguage(x.Item));
      }
    }

    public IEnumerable<SimpleItem> Children
    {
      get
      {
        return InnerItem.Children.Select(x => new SimpleItem(x));
      }
    }

    public static class FieldId
    {
      public static readonly ID Title = new ID("{234542DC-C610-4CA8-BAA6-2592A8BCB1D7}");
      public static readonly ID MenuTitle = new ID("{D7229DBA-B952-4D82-A5A0-459C69618D45}");
      public static readonly ID Abstract = new ID("{00E1D306-96BD-4B32-85B4-CD63C53CC6C1}");
      public static readonly ID Body = new ID("{5A5684BB-8B54-44F6-ABCC-2BADA05ADA5D}");
      public static readonly ID Icon = new ID("{2B60D8C1-81DB-45A7-B1CB-654CDDA96AE3}");
    }
  }  
}