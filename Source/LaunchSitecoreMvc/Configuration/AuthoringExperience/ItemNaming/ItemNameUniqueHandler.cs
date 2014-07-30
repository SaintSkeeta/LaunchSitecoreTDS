using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;

namespace LaunchSitecore.Configuration.AuthoringExperience.ItemNaming
{
  public class ItemNameUniqueHandler
  {
    protected void OnItemSaving(object sender, EventArgs args)
    {
      //ensures arguments aren't null
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(args, "args");

      //gets item parameter from event arguments
      object obj = Event.ExtractParameter(args, 0);
      Item item = obj as Item;
      if (item != null)
      {
        if (item.Parent != null)
        {
          while (ParentHasChildWithName(item))
          {
            item.Name = String.Format("{0}-{1}", item.Name, 1);
          }          
        }
      }
    }

    private bool ParentHasChildWithName(Item current)
    {
      foreach (Item child in current.Parent.Children)
       {
         if (current.Name == child.Name && current.ID != child.ID) return true;
       }
       return false;
    }
  }
}