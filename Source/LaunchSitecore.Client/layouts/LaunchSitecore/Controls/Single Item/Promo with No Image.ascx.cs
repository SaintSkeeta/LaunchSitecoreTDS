using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Links;
using Sitecore.Data.Items;
using Sitecore.Data;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Promo_with_No_Image : SitecoreSingleItemUserControl
  {
    protected void Page_Load(object sender, EventArgs e)
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