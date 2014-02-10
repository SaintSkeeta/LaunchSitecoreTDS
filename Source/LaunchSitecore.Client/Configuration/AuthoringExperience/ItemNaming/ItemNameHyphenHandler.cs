using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;

// http://www.cognifide.com/blogs/sitecore/sitecore-best-practice-9/
/*
 if Replace dashes in name then replace
 * if desiplay name then replace
 * 
 * verifyt that $name is the original text not the converted
 * 
 * In the job and in this handler make sure that the item has presentaiton before changing
 * 
 * move the main partof the code to a method so that we can reuse the code.
 */

namespace LaunchSitecore.Configuration.AuthoringExperience.ItemNaming
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
                ItemNamingHelper.UpdateItemNames(item);
            }
        }        
    }
}