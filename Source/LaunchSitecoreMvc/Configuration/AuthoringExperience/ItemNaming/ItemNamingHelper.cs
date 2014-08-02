using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Configuration.AuthoringExperience.ItemNaming
{
  public class ItemNamingHelper
  {
    private static readonly SynchronizedCollection<Sitecore.Data.ID> inProcess = new SynchronizedCollection<Sitecore.Data.ID>();
    
    public static void UpdateItemNames(Item item)
    {
      UpdateItemNames(item, false);
    }

    public static void UpdateItemNames(Item item, bool reverseDashes)
    {
      if (inProcess.Contains(item.ID))
      {
        return;
      }

      inProcess.Add(item.ID);
      try
      {
          // check if item name contains " " and that it is under the content root item
          if (IsContentRoot(item) && HasPresentation(item))
          {
            item.Editing.BeginEdit();
            if (MakeItemNamesSEOFriendly())
            {
              if (StorePrettyNameInDisplayName())
              {
                item.Appearance.DisplayName = item.Name.Replace("-"," ");  // the replace is only required because existing items may have dashes and our command updates all items.
              }
              else
              {
                item.Fields["__Display name"].Reset();
              }

              item.Name = item.Name.Replace(" ", "-"); //replaces " " with "-"  
            }

            if (reverseDashes && !MakeItemNamesSEOFriendly())
            {
              item.Name = item.Name.Replace("-", " "); //replaces "-" with " "
              item.Fields["__Display name"].Reset();
            }            
            item.Editing.EndEdit();
          }        
      }
      finally
      {
        inProcess.Remove(item.ID);
      }
    }
           
    public static bool MakeItemNamesSEOFriendly()
    {
      Database master = Factory.GetDatabase("master");
      Item itemNaming = master.GetItem("/sitecore/system/Modules/Launch Sitecore/Settings/Item Naming");
      if (itemNaming != null && itemNaming["Replace Spaces with Dashes in Item Names"] == "1") 
         return true;

      return false;
    }

    public static bool StorePrettyNameInDisplayName()
    {
      Database master = Factory.GetDatabase("master");
      Item itemNaming = master.GetItem("/sitecore/system/Modules/Launch Sitecore/Settings/Item Naming");
      if (itemNaming != null && itemNaming["Store Pretty Name in Display Name"] == "1")
        return true;

      return false;
    }
    
    public static bool IsContentRoot(Item item)
    {
      if (Sitecore.Context.ContentDatabase != null && Sitecore.Context.ContentDatabase.Name.ToLower() == "master" && item.Database.Name.ToLower() == "master")
      {
        Item contentRootItem = Sitecore.Context.ContentDatabase.GetItem("/sitecore/content");
        while (item.Parent != null)
        {
          if (item.ID == contentRootItem.ID) { return true; }
          item = item.Parent;
        }
      }

      return false;
    }

    public static bool AreContentEditorWarningsOn()
    {
      Database master = Factory.GetDatabase("master");
      Item itemNaming = master.GetItem("/sitecore/system/Modules/Launch Sitecore/Settings/Item Naming");
      if (itemNaming != null && itemNaming["Show Content Editor Warnings"] == "1")
        return true;

      return false;
    }

    public static bool HasPresentation(Item item)
    {
      if (item.Visualization.Layout != null) return true;
      return false;
    }

    public static void RecursiveItemSave(Item i, bool reverseDashes)
    {
      foreach (Item a in i.Children)
      {
        ItemNamingHelper.UpdateItemNames(a, reverseDashes);
        RecursiveItemSave(a, reverseDashes);
      }
    }
  }
}