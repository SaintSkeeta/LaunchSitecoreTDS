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
using LaunchSitecore.Configuration.Presentation;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation
{
    public partial class Main_Navigation : System.Web.UI.UserControl
    {
        Item HomeItem;

        private void Page_Load(object sender, EventArgs e)
        {
            Sitecore.Diagnostics.Tracer.Info("Main Navigation - Page Load");
            Sitecore.Diagnostics.Profiler.StartOperation("Main Navigation - Page Load");
        
            Item presentationSettings = SiteConfiguration.GetPresentationSettingsItem();
            if (presentationSettings["Main Menu Type"] == "Mega Nav")
            {
                dropdownwrapper.Visible = false;
                LoadMegaNavMenu();

                // The mega nav requires a little jquery...
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterClientScriptBlock(cstype, "InitializeMenu", "<script type=\"text/javascript\">var $j = jQuery.noConflict(); $j(document).ready(function ($j) { $j('#mega-menu-1').dcMegaMenu(); });</script>");
            }
            else
            {
                rptMegaNavMenu.Visible = false;
                LoadDropDownMenu();
            }
                       
            Sitecore.Diagnostics.Profiler.EndOperation("Main Navigation - Page Load");
        }
        
        private void LoadDropDownMenu()
        {
            Sitecore.Diagnostics.Tracer.Info("Drop Down Navigation - Page Load");
            Sitecore.Diagnostics.Profiler.StartOperation("Drop Down Navigation - Page Load");

            HomeItem = SiteConfiguration.GetHomeItem();
            List<Item> nodes = new List<Item>();
            nodes.Add(HomeItem);
            foreach (Item i in HomeItem.Children)
            {
                if (i.Versions.Count > 0 && i["Hide Item from Menu"] != "1") { nodes.Add(i); }
            }

            rptDropDownMenu.DataSource = nodes;
            rptDropDownMenu.DataBind();

            Sitecore.Diagnostics.Profiler.EndOperation("Drop Down Navigation - Page Load");
        }

        private void LoadMegaNavMenu()
        {
            Sitecore.Diagnostics.Tracer.Info("Mega Nav Navigation - Page Load");
            Sitecore.Diagnostics.Profiler.StartOperation("Mega Nav Navigation - Page Load");

            HomeItem = SiteConfiguration.GetHomeItem();
            List<Item> nodes = new List<Item>();
            nodes.Add(HomeItem);
            foreach (Item i in HomeItem.Children)
            {
                if (i.Versions.Count > 0 && i["Hide Item from Menu"] != "1") { nodes.Add(i); }
            }

            rptMegaNavMenu.DataSource = nodes;
            rptMegaNavMenu.DataBind();

            Sitecore.Diagnostics.Profiler.EndOperation("Mega Nav Navigation - Page Load");
        }

        protected void rptDropDownMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
         
                        if (node["Hide Children from Menu"] != "1" && node.HasChildren)
                        {
                            PlaceHolder phSubTree = (PlaceHolder)e.Item.FindControl("phSubMenu");
                            
                            List<Item> nodes = new List<Item>();                            
                            foreach (Item i in node.Children)
                            {
                                if (i.Versions.Count > 0 && i["Hide Item from Menu"] != "1") { nodes.Add(i); }
                            }

                            Repeater rpt = new Repeater();
                            rpt.DataSource = nodes;
                            rpt.HeaderTemplate = rptDropDownMenu.HeaderTemplate;
                            rpt.ItemTemplate = rptDropDownMenu.ItemTemplate;
                            rpt.FooterTemplate = rptDropDownMenu.FooterTemplate;
                            rpt.ItemDataBound += new RepeaterItemEventHandler(rptDropDownMenu_ItemDataBound);
                            phSubTree.Controls.Add(rpt);
                            rpt.DataBind();
                        }
                    }
                }
            }
        }

        private bool MoreLevelsToShow(Item i)
        {
            int levelsToHome = 0;
            while (i.ID != HomeItem.ID)
            {
                levelsToHome++;
                i = i.Parent;
            }

            if (levelsToHome <= 2) return true;

            return false;
        }

        protected void rptMegaNavMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

                        if (node["Hide Children from Menu"] != "1" && node.HasChildren && MoreLevelsToShow(node))
                        {
                            PlaceHolder phSubTree = (PlaceHolder)e.Item.FindControl("phSubMenu");

                            List<Item> nodes = new List<Item>();
                            foreach (Item i in node.Children)
                            {
                                if (i.Versions.Count > 0 && i["Hide Item from Menu"] != "1") { nodes.Add(i); }
                            }

                            Repeater rpt = new Repeater();
                            rpt.DataSource = nodes;
                            rpt.HeaderTemplate = new RecursiveRepeaterTemplate(ListItemType.Header);
                            rpt.ItemTemplate = rptMegaNavMenu.ItemTemplate;
                            rpt.FooterTemplate = new RecursiveRepeaterTemplate(ListItemType.Footer);
                            rpt.ItemDataBound += new RepeaterItemEventHandler(rptMegaNavMenu_ItemDataBound);
                            phSubTree.Controls.Add(rpt);
                            rpt.DataBind();
                        }
                    }
                }
            }
        }        
    }
}
