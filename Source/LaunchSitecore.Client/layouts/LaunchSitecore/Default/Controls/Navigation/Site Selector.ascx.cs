using System;
using LaunchSitecore.Configuration;
using Sitecore.Data.Items;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation
{
    public partial class Site_Selector : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item contentNode = SiteConfiguration.GetHomeItem().Parent;      
            List<Item> sites = new List<Item>();
            List<Item> externalsites = new List<Item>();
            
            foreach (Item site in contentNode.Children)
            {
                 if (site["Show in Sites Menu"] == "1") { sites.Add(site); }
            }

            if (SiteConfiguration.GetExternalSitesItem() != null)
            {
                foreach (Item externalsite in SiteConfiguration.GetExternalSitesItem().Children)
                {
                    externalsites.Add(externalsite);
                }
            }

            if (sites.Count + externalsites.Count > 1) // Don't show the drop down unless there are multiple sites
            {
                SitesLink.Text = SiteConfiguration.GetDictionaryText("Sites");
                //SitesLink.NavigateUrl = "#";
                if (sites.Count > 0)
                {
                    rptList.DataSource = sites;
                    rptList.DataBind();
                }

                if (sites.Count > 0 && externalsites.Count > 0) { divider.Visible = true; }

                if (externalsites.Count > 0)
                {
                    rptExternal.DataSource = externalsites;
                    rptExternal.DataBind();
                }
            }
            else
            {
                SitesLink.Visible = false;
            }
        }
        
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                HyperLink LinkTo = (HyperLink)e.Item.FindControl("LinkTo");
                
                if (LinkTo != null)
                {
                    LinkTo.NavigateUrl = LinkManager.GetItemUrl(node);
                    LinkTo.Text = node["Site Name"];                    
                }
            }
        }

        protected void rptExternal_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;                               
                Link LinkTo = (Link)e.Item.FindControl("LinkTo");
                
                if (LinkTo != null)
                {
                    LinkTo.Item = node;                    
                }
            }
        }
    }
}