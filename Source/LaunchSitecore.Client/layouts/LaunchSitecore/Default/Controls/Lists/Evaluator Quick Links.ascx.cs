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
    public partial class Evaluator_Quick_Links : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            MultilistField items = Sitecore.Context.Item.Fields["Quick Links"];
            rptItems.DataSource = items.GetItems();
            rptItems.DataBind();                      
        }

        protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {            
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