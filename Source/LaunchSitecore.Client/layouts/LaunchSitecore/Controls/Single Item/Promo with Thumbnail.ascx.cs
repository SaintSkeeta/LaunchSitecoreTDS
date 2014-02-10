using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Promo_with_Thumbnail : SitecoreSingleItemUserControl
  {
    private void Page_Load(object sender, EventArgs e)
    {
      WriteAlertsIfNeeded();
      HideIfNoVersionUnlessPageEditing();

      if (IsDataSourceItemNull)
      {
        pnl.Visible = false;        
      }
      else
      {
        if (DataSourceItem["Link To"] != String.Empty && Sitecore.Context.Database.GetItem(new ID(DataSourceItem["Link To"])) != null)
        {          
          LinkTo.NavigateUrl = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(new ID(DataSourceItem["Link To"])));
        }
        else
        {
          LinkTo.Visible = false;
        }
      }
    }
  }
}