using System;
using Sitecore.Links;
using LaunchSitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Data;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content
{
    public partial class Promo_Spot_with_Thumbnail : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
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
                Thumbnail.Item = DataSourceItem;
                Title.Item = DataSourceItem;
                Abstract.Item = DataSourceItem;

                if (DataSourceItem["Link To"] != String.Empty)
                {
                    Item targetItem = Sitecore.Context.Database.GetItem(new ID(DataSourceItem["Link To"]));
                    LinkTo.NavigateUrl = LinkManager.GetItemUrl(targetItem);
                    LinkTo.Text = SiteConfiguration.GetDictionaryText("Learn More");
                }
                else
                {
                    LinkTo.Visible = false;
                }
            }
        }
    }
}