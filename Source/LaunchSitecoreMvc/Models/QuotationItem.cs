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
  public class QuotationItem : CustomItem
  {
    public QuotationItem(Item item) : base(item)
    {
      Assert.IsNotNull(item, "item");      
    }

    public string Author
    {
      get { return InnerItem[FieldId.Author]; }
    }

    public string Quote
    {
      get { return InnerItem[FieldId.Quote]; }
    }
    
    public Item Item
    {
      get { return InnerItem; }
    }    

    public static class FieldId
    {
      public static readonly ID Author = new ID("{07EDEBCF-EE2C-4F64-A5FD-1DF221DF0014}");
      public static readonly ID Quote = new ID("{60B57A34-140A-4E04-B576-E390D08E3231}");     
    }
  }  
}