using LaunchSitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaunchSitecore.Configuration.SiteUI;

namespace LaunchSitecore.Models
{
  public class PromoItem : CustomItem
  {
    public PromoItem(Item item)
      : base(item)
    {
      Assert.IsNotNull(item, "item");      
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string Text
    {
      get { return InnerItem[FieldId.Text]; }
    }
    
    public string ItemIcon
    {
      get { return InnerItem[FieldId.Icon]; }
    }

    public string Image
    {
      get { return InnerItem[FieldId.Image]; }
    }

    public string LinkText
    {
      get { return InnerItem[FieldId.LinkText]; }
    }

    public string LinkToUrl
    {
      get { return InnerItem.GetLink("Link To"); }
    }
    
    public Item Item
    {
      get { return InnerItem; }
    }    

    public static class FieldId
    {
      public static readonly ID Title = new ID("{BE8278A4-8653-4F35-8A25-6E089D8E3462}");
      public static readonly ID Text = new ID("{E96DFA10-FA94-4B0F-9612-27FC15439797}");
      public static readonly ID Icon = new ID("{2B60D8C1-81DB-45A7-B1CB-654CDDA96AE3}");
      public static readonly ID Image = new ID("{E51F0A11-F315-4020-AC5B-1AC24AAF7169}");
      public static readonly ID LinkText = new ID("{DD45E0B2-E160-4291-8F50-1EBBC39AB445}");
      
    }
  }  
}