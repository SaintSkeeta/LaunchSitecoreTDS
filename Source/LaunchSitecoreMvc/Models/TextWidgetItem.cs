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
  public class TextWidgetItem : CustomItem
  {
    public TextWidgetItem(Item item)
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
   
    public Item Item
    {
      get { return InnerItem; }
    }    

    public static class FieldId
    {
      public static readonly ID Title = new ID("{C917546A-3267-4FF5-890E-9D96EF88C2AF}");
      public static readonly ID Text = new ID("{6634B489-5F9B-4A80-897D-6E683BD88AAC}");      
    }
  }  
}