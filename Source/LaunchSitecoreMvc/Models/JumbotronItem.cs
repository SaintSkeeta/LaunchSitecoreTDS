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
  public class JumbotronItem : CustomItem
  {
    public JumbotronItem(Item item) : base(item)
    {
      Assert.IsNotNull(item, "item");      
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string Body
    {
      get { return InnerItem[FieldId.Body]; }
    }

    public string CallToActionText
    {
      get { return InnerItem[FieldId.CallToActionText]; }
    }
    
    public string LinkToUrl
    {
      get { return InnerItem.GetLink("Call to Action Link"); }
    }
   
    public bool HasLink
    {
      get { return InnerItem.GetLink("Call to Action Link") != String.Empty ? true : false; }
    }

    public Item Item
    {
      get { return InnerItem; }
    }    

    public static class FieldId
    {
      public static readonly ID Title = new ID("{AAEAC7F2-E33E-4B34-9023-AB6F59D3A427}");
      public static readonly ID Body = new ID("{764646D1-347E-419D-8B86-67457C73D905}");
      public static readonly ID CallToActionText = new ID("{4B8CFF92-ABB0-4D0A-A396-CD2AD4B5A99B}"); 
    }
  }  
}