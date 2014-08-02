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
  public class MenuItem : CustomItem
  {
    public MenuItem(Item item) : base(item)
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

    public bool ShowItemInMenu
    {
      get { return InnerItem[FieldId.ShowItemInMenu] == "1" ? true : false; }
    }

    public bool ShowItemInSecondaryMenu
    {
      get { return InnerItem[FieldId.ShowItemInSecondaryMenu] == "1" ? true : false; }
    }

    public bool ShowChildrenInMenu
    {
      get { return InnerItem[FieldId.ShowChildrenInMenu] == "1" ? true : false; }
    }

    public bool IsActive
    {
      get { return Sitecore.Context.Item.ID == InnerItem.ID; }
    }

    public bool IsActiveADescendant
    {
      get { return Sitecore.Context.Item.ID == InnerItem.ID || InnerItem.Axes.SelectItems(String.Format(".//*[@@id = '{0}']", Sitecore.Context.Item.ID)) != null; }
      
    }
                
    public string Url
    {
      get { return LinkManager.GetItemUrl(InnerItem); }
    }

    public bool HasChildrenToShowInMenu
    {
      get { return ChildrenInMenu.Any(); }
    }

    public bool HasChildrenToShowInSecondaryMenu
    {
      get { return ChildrenInSecondaryMenu.Any(); }
    }

    public Item Item
    {
      get { return InnerItem; }
    }

    public IEnumerable<MenuItem> ChildrenInMenu
    {
      get
      {
        return ChildrenInCurrentLanguage.Where(x => x.Item["Show Item in Menu"] == "1");
      }
    }

    public IEnumerable<MenuItem> ChildrenInSecondaryMenu
    {
      get
      {
        return ChildrenInCurrentLanguage.Where(x => x.Item["Show Item in Secondary Menu"] == "1");
      }
    }

    public IEnumerable<MenuItem> ChildrenInCurrentLanguage
    {
      get
      {
        return Children.Where(x => SiteConfiguration.DoesItemExistInCurrentLanguage(x.Item));
      }
    }

    public IEnumerable<MenuItem> Children
    {
      get
      {
        return InnerItem.Children.Select(x => new MenuItem(x));
      }
    }

    public static class FieldId
    {
      public static readonly ID Title = new ID("{234542DC-C610-4CA8-BAA6-2592A8BCB1D7}");
      public static readonly ID MenuTitle = new ID("{D7229DBA-B952-4D82-A5A0-459C69618D45}");
      public static readonly ID ShowItemInMenu = new ID("{7E003143-26F2-4A28-B70A-08548286F6BA}");
      public static readonly ID ShowItemInSecondaryMenu = new ID("{FD6DAC05-FEF8-4581-A329-6CEA310E839B}");
      public static readonly ID ShowChildrenInMenu = new ID("{D48AF62C-9C56-4E4C-BA29-94C3DABAD82E}");
    }
  } 
}