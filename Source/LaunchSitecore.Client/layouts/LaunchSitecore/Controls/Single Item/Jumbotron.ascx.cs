using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Jumbotron : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      Item calltoactionitem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item["Call to Action Link"]);
      if (calltoactionitem != null)
      {
        calltoaction.NavigateUrl = LinkManager.GetItemUrl(calltoactionitem);
        calltoaction.Text = Sitecore.Context.Item["Call to Action Text"];
      }
    }
  }
}