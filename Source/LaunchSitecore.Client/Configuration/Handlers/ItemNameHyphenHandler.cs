using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;

namespace LaunchSitecore.Configuration.Handlers
{
    public class ItemNameHyphenHandler
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
                // check if item name contains "-" and that it is under the content root item
                if (item.Name.Contains("-") && IsContentRoot(item)) 
                {
                    item.Editing.BeginEdit();
                    item.Name = item.Name.Replace("-", " "); //replaces "-" with " "
                    item.Editing.EndEdit();
                }
            }
        }

        public static bool IsContentRoot(Item item)
        {
            if (Sitecore.Context.ContentDatabase != null && Sitecore.Context.ContentDatabase.Name == "master")
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
    }
}