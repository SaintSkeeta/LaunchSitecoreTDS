using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Configuration.SiteUI.Search.Helper
{
  public class ItemIDComparer : IEqualityComparer<Item>
  {    
      public bool Equals(Item x, Item y)
      {
        return x.ID == y.ID;
      }

      public int GetHashCode(Item obj)
      {
        return obj.ID.GetHashCode();
      }    
  }
}