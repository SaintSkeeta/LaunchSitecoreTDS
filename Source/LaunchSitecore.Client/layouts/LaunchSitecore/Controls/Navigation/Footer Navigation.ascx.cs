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

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation
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
              if (i != null && SiteConfiguration.DoesItemExistInCurrentLanguage(i)) { nodes.Add(i); }              
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
                    }
                }
            }
        }        
    }
}
