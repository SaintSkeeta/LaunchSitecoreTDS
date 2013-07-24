using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using System.Collections.Generic;
using LaunchSitecore.Configuration;
using System.Web.UI.WebControls;
using Sitecore.Links;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation
{
    public partial class Breadcrumbs : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.ID != SiteConfiguration.GetHomeItem().ID)
            {
                List<Item> items = new List<Item>();

                Database currentdb = Sitecore.Context.Database;
                Item temp = Sitecore.Context.Item;

                while (temp.ID != SiteConfiguration.GetHomeItem().ParentID)
                {
                    items.Add(temp);
                    temp = temp.Parent;
                }

                items.Reverse();
                rptCrumbs.DataSource = items;
                rptCrumbs.DataBind();
            }
        }

        protected void rptCrumbs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink CrumbLink = (HyperLink)e.Item.FindControl("CrumbLink");
                    Literal CrumbLiteral = (Literal)e.Item.FindControl("CrumbLiteral");

                    if (CrumbLink != null && CrumbLiteral != null)
                    {                    
                        // the current page doesn't need to be a link
                        if (node.ID == Sitecore.Context.Item.ID)
                        {
                            CrumbLiteral.Text = node["Menu Title"];
                            CrumbLink.Visible = false;
                            CrumbLiteral.Visible = true;
                        }
                        else
                        {
                            CrumbLink.Text = node["Menu Title"];
                            CrumbLink.NavigateUrl = LinkManager.GetItemUrl(node);
                        }                            
                    }
                }
            }
        }
    }
}
