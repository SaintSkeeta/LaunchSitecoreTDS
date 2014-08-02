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
  public class StickyNoteItem : CustomItem
  {
    public StickyNoteItem(Item item) : base(item)
    {
      Assert.IsNotNull(item, "item");      
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string Message
    {
      get { return InnerItem[FieldId.Message]; }
    }

    public string NoteType
    {
      get { return InnerItem[FieldId.NoteType]; }
    }
  
    public string SmallCssClass
    {
      get { return String.Format("{0}-sidestick sidebar-stick", NoteType); }
    }

    public string RegularCssClass
    {
      get { return String.Format("span3 {0}-stick stick", NoteType); }
    }

    public Item Item
    {
      get { return InnerItem; }
    }  
  
    public static class FieldId
    {
      public static readonly ID Title = new ID("{6EF91885-9825-44ED-ACF4-CB8885F7A214}");
      public static readonly ID Message = new ID("{6AE2D82D-0CF4-47B7-B71C-BC50BFD9E199}");
      public static readonly ID NoteType = new ID("{FBDB294E-D5B3-479E-A922-B3D54E1F8053}");     
    }
  }  
}