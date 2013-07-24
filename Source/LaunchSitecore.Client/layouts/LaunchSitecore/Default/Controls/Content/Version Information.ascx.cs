using System;
using Sitecore.Data.Items;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content
{
    public partial class Version_Information : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item versionItem = SiteConfiguration.GetVersionInformationItem();
            // We only want the pull down to work in regular mode.
            if (!Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging)
            {
                InNormalMode.Visible = false;
                LS_VersionRO.Item = versionItem;
            }
            else
            {
                LS_VersionRO.Visible = false;
                LS_Version.Item = versionItem;
                Image.Item = versionItem;
                Body.Item = versionItem;
                Title.Item = versionItem;
                Version.Item = versionItem;
            }
        }
    }
}