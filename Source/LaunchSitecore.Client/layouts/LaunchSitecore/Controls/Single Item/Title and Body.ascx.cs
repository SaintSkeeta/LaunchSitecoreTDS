using LaunchSitecore.Configuration.SiteUI.Base;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Title_and_Body : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      // not all pages have subtitles so we may want to hide the h2
      if (Sitecore.Context.Item.Fields["SubTitle"] != null) subtitlewrapper.Visible = true;
    }
  }
}