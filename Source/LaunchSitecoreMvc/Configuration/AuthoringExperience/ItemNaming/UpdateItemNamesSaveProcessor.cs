using Sitecore.Pipelines.Save;
using System;
using Sitecore.Data.Items;
using LaunchSitecore.Configuration.ItemNaming;
using Sitecore.Data;
using Sitecore.Configuration;

namespace LaunchSitecore.Configuration.ItemNaming
{
  // The html editor occasionally puts in a non-breaking space instead of a space.  Browsers also, send a &nbsp; if 
  // the preceding character was a space.  Since this is not xhtml compatible, I am removing them on save.

  public class UpdateItemNamesSaveProcessor
  {
    public void Process(SaveArgs args)
    {
      foreach (Sitecore.Pipelines.Save.SaveArgs.SaveItem saveItem in args.Items)
      {
        if (saveItem.ID == new ID("{47729EC5-14AA-4B1B-8BA9-EC0A3AEF2953}"))  // The Global Setting Item Naming Item
        {
          Database master = Factory.GetDatabase("master");
          Item content = master.GetItem("/sitecore/content");
          Helper.RecursiveItemSave(content, false);
        }
      }
    }    
  }
}