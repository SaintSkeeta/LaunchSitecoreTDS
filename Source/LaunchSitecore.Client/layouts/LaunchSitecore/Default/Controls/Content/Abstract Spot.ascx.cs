using System;
using Sitecore.Links;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content
{
     public partial class Abstract_Spot : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (IsDataSourceItemNull)
            {
                // The datasource is null so, degrade gracefully
                this.Visible = false;    
            }
            else
            {
                LinkTo.NavigateUrl = LinkManager.GetItemUrl(DataSourceItem);
                LinkTo.Text = SiteConfiguration.GetDictionaryText("Read More");
                Title.Item = DataSourceItem;
                Abstract.Item = DataSourceItem;
            }
        }
    }
}