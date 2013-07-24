using System;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content
{
    public partial class Term_Details : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            DefinitionLabel.Text = SiteConfiguration.GetDictionaryText("Definition");
            ImageLabel.Text = SiteConfiguration.GetDictionaryText("Image");
            UsageLabel.Text = SiteConfiguration.GetDictionaryText("Usage");
        }
    }
}