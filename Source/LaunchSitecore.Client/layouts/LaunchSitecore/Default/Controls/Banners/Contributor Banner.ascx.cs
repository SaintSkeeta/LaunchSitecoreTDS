using System;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Banners
{
    public partial class Contributor_Banner : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            LocationTitle.Text = SiteConfiguration.GetDictionaryText("Location");
        }
    }
}