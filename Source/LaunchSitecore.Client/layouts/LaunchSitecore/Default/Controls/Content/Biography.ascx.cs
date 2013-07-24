using System;
using LaunchSitecore.Configuration;
using Sitecore.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content
{
    public partial class Biography : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BiographyTitle.Text = SiteConfiguration.GetDictionaryText("Biography");             
        }      
    }
}