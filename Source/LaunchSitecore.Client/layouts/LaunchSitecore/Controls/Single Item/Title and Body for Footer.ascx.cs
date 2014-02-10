using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Title_and_Body_for_Footer : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      // if the datasource is not specified use the home item.
      if (Sitecore.Context.Item.ID == DataSourceItemOrCurrentItem.ID)
      {
        frTitle.Item = SiteConfiguration.GetHomeItem();
        frBody.Item = SiteConfiguration.GetHomeItem();
      }
    }
  }
}