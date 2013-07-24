using System;
using LaunchSitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Links;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation
{
    public partial class Mobile_Menu : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Sitecore.Diagnostics.Tracer.Info("Mobile Menu - Page Load");
            Sitecore.Diagnostics.Profiler.StartOperation("Mobile Menu - Page Load");
                            
            Item HomeItem = SiteConfiguration.GetHomeItem();
            List<Item> nodes = new List<Item>();
            nodes.Add(HomeItem);
            foreach (Item i in HomeItem.Children)
            {
                if (i["Hide Item from Menu"] != "1") { nodes.Add(i); }
            }
            rptMenu.DataSource = nodes;
            rptMenu.DataBind();
          
            Sitecore.Diagnostics.Profiler.EndOperation("Mobile Menu - Page Load");
        }

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink MenuLink = (HyperLink)e.Item.FindControl("MenuLink");                    
                    Literal MenuText = (Literal)e.Item.FindControl("MenuText");
                    
                    if (MenuLink != null && MenuText != null)
                    {
                        MenuText.Text = node["Menu Title"];                        
                        MenuLink.NavigateUrl = LinkManager.GetItemUrl(node);                         
                    }
                }
            }
        }
    }
}
