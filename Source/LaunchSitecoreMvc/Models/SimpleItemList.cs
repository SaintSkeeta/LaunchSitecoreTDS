using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System.Xml.Serialization;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.Models
{
  public class SimpleItemList
  {
    public string Title { get; protected set; }
    public IEnumerable<SimpleItem> Items { get; protected set; }

    public SimpleItemList(string title, IEnumerable<SimpleItem> items)
    {
      Title = title;
      Items = items;
    }
  }
}