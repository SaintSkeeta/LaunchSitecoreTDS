using System.Collections.Generic;
using Sitecore.Data.Items;

namespace LaunchSitecore.Configuration.Comparers
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