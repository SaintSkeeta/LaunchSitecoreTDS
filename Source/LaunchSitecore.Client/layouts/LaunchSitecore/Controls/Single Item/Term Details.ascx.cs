using LaunchSitecore.Configuration.SiteUI.Base;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Term_Details : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      DefinitionLabel.Text = GetDictionaryText("Definition");
      UsageLabel.Text = GetDictionaryText("Usage");
    }
  }
}