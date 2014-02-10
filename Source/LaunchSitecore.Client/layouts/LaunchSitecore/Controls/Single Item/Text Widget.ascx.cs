using LaunchSitecore.Configuration.SiteUI.Base;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Text_Widget : SitecoreSingleItemUserControl
  {
    private void Page_Load(object sender, EventArgs e)
    {
      WriteAlertsIfNeeded();
      HideIfNoVersionUnlessPageEditing();

      if (IsDataSourceItemNull)
      {
        pnl.Visible = false;
      }
    }
  }
}