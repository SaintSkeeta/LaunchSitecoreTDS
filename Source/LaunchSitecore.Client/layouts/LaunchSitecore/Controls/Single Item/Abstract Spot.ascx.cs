using System;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Links;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class AbstractSpot : SitecoreSingleItemUserControl
  {
    private void Page_Load(object sender, EventArgs e)
    {
      WriteAlertsIfNeeded();
      HideIfNoVersionUnlessPageEditing();

      if (IsDataSourceItemNull)
      {
        if (IsPageEditorEditing)
        {
          pnlAbstract.Visible = false;          
        }        
      }      
      else
      {        
        LinkTo.NavigateUrl = LinkManager.GetItemUrl(DataSourceItem);
        LinkTo.Text = String.Format("{0}&nbsp;»", GetDictionaryText("Learn more"));       
      }
    }
  }
}