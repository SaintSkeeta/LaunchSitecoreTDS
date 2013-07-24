using System;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using LaunchSitecore.Configuration;
using Sitecore.Links;
using System.Collections.Generic;
using Sitecore.Data;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{
    public partial class Queried_List : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            string query = "";
            Item queryItem = DataSourceItem;
            query = queryItem["Query"];
            Item[] items = Sitecore.Context.Item.Axes.SelectItems(query);
            
            if (items != null && items.Length > 0)
            {
                rptItems.DataSource = items;
                rptItems.DataBind();
            }
            else
            {
                if (Sitecore.Context.PageMode.IsPageEditorEditing)
                {
                    showIfEmpty.Visible = true;
                }
            }
        }

        protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {   
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink LinkTo = (HyperLink)e.Item.FindControl("LinkTo");
                    FieldRenderer ItemName = (FieldRenderer)e.Item.FindControl("ItemName");
                    FieldRenderer ItemAbstract = (FieldRenderer)e.Item.FindControl("ItemAbstract");

                    if (LinkTo != null && ItemName != null && ItemAbstract != null)
                    {
                        LinkTo.NavigateUrl = LinkManager.GetItemUrl(node);
                        LinkTo.Text = SiteConfiguration.GetDictionaryText("Read More");
                        ItemName.Item = node;
                        ItemAbstract.Item = node;
                    }
                }
            }
        }
    }
}