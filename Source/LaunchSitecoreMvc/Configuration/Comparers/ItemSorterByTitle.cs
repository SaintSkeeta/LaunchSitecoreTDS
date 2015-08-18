using Sitecore.Data.Comparers;
using Sitecore.Data.Items;

namespace LaunchSitecore.Configuration.Comparers
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