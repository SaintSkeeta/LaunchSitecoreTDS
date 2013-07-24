using System;
using System.Web;
using System.Web.UI;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default
{
    public partial class Mobile : Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            Response.AddHeader("Vary", "User-Agent");
            Logo.Item = SiteConfiguration.GetPresentationSettingsItem();
            litMenu.Text = SiteConfiguration.GetDictionaryText("Menu");
            litClose.Text = SiteConfiguration.GetDictionaryText("Close");

            if (!Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging)
            {
                DMSViewer.Visible = false;
            }
        }
    }
}
