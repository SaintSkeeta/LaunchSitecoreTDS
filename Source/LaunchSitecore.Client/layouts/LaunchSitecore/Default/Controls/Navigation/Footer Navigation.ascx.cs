using System;
using LaunchSitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Links;
using System.Web.UI;
using Sitecore.Collections;
using System.Collections.Generic;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation
{
    public partial class Footer_Navigation : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Sitecore.Diagnostics.Tracer.Info("Footer Navigation - Page Load");
            Sitecore.Diagnostics.Profiler.StartOperation("Footer Navigation - Page Load");

            Item baseItem = SiteConfiguration.GetFooterLinksItem();
            List<Item> nodes = new List<Item>();
            foreach (Item footerLink in baseItem.Children)
            {
                Item i = Sitecore.Context.Database.GetItem(footerLink["Top Level Item"]);
                // the item will be null if it doesn't have a version in the current language
                if (i != null) { nodes.Add(i); }
            }       
                    
            rptMenu.DataSource = nodes;
            rptMenu.DataBind();

            Sitecore.Diagnostics.Profiler.EndOperation("Footer Navigation - Page Load");
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
                                 
                        Repeater rpt = (Repeater)e.Item.FindControl("rptSub");

                        if (rpt != null)
                        {
                            List<Item> nodes = new List<Item>();
                            foreach (Item i in node.Children)
                            {
                                if (i != null && i["Hide Item from Menu"] != "1")
                                {
                                        nodes.Add(i);                                
                                }
                            }

                            rpt.DataSource = nodes;
                            rpt.ItemDataBound += new RepeaterItemEventHandler(rptMenu_ItemDataBound);
                            rpt.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptSubMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
