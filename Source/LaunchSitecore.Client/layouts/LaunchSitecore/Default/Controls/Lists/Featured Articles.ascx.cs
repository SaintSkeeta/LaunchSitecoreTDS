using System;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using LaunchSitecore.Configuration;
using Sitecore.Links;
using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Fields;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{
    public partial class Featured_Articles : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            MultilistField items = (MultilistField)Sitecore.Context.Item.Fields["Featured Articles"];

            if (items != null && items.Items.Length > 0)
            {
                rptItems.DataSource = items.GetItems();
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
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");
                if (SectionTitle != null)
                {
                    SectionTitle.Text = SiteConfiguration.GetDictionaryText("Featured Articles");
                }
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink ItemLink = (HyperLink)e.Item.FindControl("ItemLink");
                    FieldRenderer ItemName = (FieldRenderer)e.Item.FindControl("ItemName");
                    FieldRenderer ItemAbstract = (FieldRenderer)e.Item.FindControl("ItemAbstract");

                    if (ItemLink != null && ItemName != null && ItemAbstract != null)
                    {
                        ItemLink.NavigateUrl = LinkManager.GetItemUrl(node);
                        ItemName.Item = node;
                        ItemAbstract.Item = node;
                    }
                }
            }
        }
    }
}