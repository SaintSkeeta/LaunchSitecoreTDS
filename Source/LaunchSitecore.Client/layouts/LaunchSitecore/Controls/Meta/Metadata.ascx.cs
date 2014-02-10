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
            return SiteConfiguration.GetPageDescripton(Sitecore.Context.Item);
        }
    }
}