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
  public class CarouselItem : CustomItem
  {
    public CarouselItem(Item item) : base(item)
    {
      Assert.IsNotNull(item, "item");      
    }

    public string Title
    {
      get { return InnerItem[FieldId.Title]; }
    }

    public string Caption
    {
      get { return InnerItem[FieldId.Caption]; }
    }

    public string LinkText
    {
      get { return InnerItem[FieldId.LinkText]; }
    }

    public string LinkItem
    {
      get { return InnerItem[FieldId.LinkItem]; }
    }

    public string Image
    {
      get { return InnerItem[FieldId.Image]; }
    }

    public bool UseDarkText
    {
      get { return InnerItem[FieldId.UseDarkText] == "1" ? true : false; }
    }
    
    public Item Item
    {
      get { return InnerItem; }
    }

    public string LinkItemUrl
    {
      get { return InnerItem.GetLink("Link Item"); }
    }

    public static class FieldId
    {
      public static readonly ID Title = new ID("{1FD34C98-05B1-4206-A48E-14D1E0C42F6F}");
      public static readonly ID Caption = new ID("{9B14A853-F008-4145-878A-DD5A2ED7EC36}");
      public static readonly ID LinkText = new ID("{48152DDC-82D7-4E74-9B1D-EC816D278AB4}");
      public static readonly ID LinkItem = new ID("{336E27E0-7F9C-437E-B179-653F427520CC}");
      public static readonly ID Image = new ID("{DD876753-9D4B-4B70-8197-41A0EB302087}");
      public static readonly ID UseDarkText = new ID("{B1F1502E-0B97-4152-92ED-6828FA25B947}");
    }
  }  
}