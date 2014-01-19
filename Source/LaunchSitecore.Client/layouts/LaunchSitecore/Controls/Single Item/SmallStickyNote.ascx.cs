using LaunchSitecore.Configuration.SiteUI.Base;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class SmallStickyNote : SitecoreSingleItemUserControl
  {
    private void Page_Load(object sender, EventArgs e)
    {
      WriteAlertsIfNeeded();
      HideIfNoVersionUnlessPageEditing();
      
      if (!IsDataSourceItemNull)
      {
        pnlStickyNote.CssClass = String.Format("{0}-sidestick sidebar-stick", DataSourceItem.Fields["Note Type"]);
      }
      else
      {
        pnlStickyNote.Visible = false;        
      }
    }
  }
}