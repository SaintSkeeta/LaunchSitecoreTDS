using System;
using LaunchSitecore.Configuration.SiteUI.Base;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class FeaturedQuotation : SitecoreSingleItemUserControl
  {
    private void Page_Load(object sender, EventArgs e)
    {
      WriteAlertsIfNeeded();
      HideIfNoVersionUnlessPageEditing();

      if (IsDataSourceItemNull)
      {
        if (IsPageEditorEditing)
        {          
          pnlQuotation.Visible = false;
        }
      }
    }
  }
}