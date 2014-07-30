using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Data.Comparers;

namespace LaunchSitecore.Configuration.SiteUI.Presentation
{
    /// <summary>
    /// Comparer to help sort items alphabetically by title
    /// </summary>
    public class ItemSorterByTitle : Comparer
    {      
        protected override int DoCompare(Item item1, Item item2)
        {
            string x = item1["title"];
            string y = item2["title"];

            return x.CompareTo(y);
        }       
    }
}