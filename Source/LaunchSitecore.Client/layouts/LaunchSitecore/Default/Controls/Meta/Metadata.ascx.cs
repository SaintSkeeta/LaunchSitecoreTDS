using System;
using Sitecore.Data.Items;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Meta
{
    public partial class Metadata : System.Web.UI.UserControl
    {
        //  http://www.seomoz.org/blog/the-wonderful-world-of-seo-metatags       

        public string GetTitle()
        {
            return Sitecore.Context.Item["Menu Title"];
        }

        public string GetDescription()
        {
            Item item = Sitecore.Context.Item;
            string description = Sitecore.Context.Item["Body"];
            // Most items have an abstract
            if (Sitecore.Context.Item["Abstract"] != String.Empty) description = item["Abstract"];
            // Team members do not have an abstract, so just use the Bio
            if (Sitecore.Context.Item["Bio"] != String.Empty) description = item["Bio"];
            // Terms do not have an abstract, so just use the Definition
            if (Sitecore.Context.Item["Definition"] != String.Empty) description = item["Definition"];
            
            description = HtmlRemoval.StripTagsCharArray(description);            
            if (description.Length > 160) description = String.Format("{0}...", description.Substring(0, 160));

            return description.Replace("\"","'");
        }
    }
}