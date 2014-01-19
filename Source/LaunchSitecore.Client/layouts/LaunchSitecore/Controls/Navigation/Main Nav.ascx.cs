using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using LaunchSitecore.Configuration.SiteUI.Presentation;


namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation
{
  public partial class Main_Nav : SitecoreUserControlBase
  {
      Item HomeItem;

      private void Page_Load(object sender, EventArgs e)
      {
        Sitecore.Diagnostics.Tracer.Info("Main Navigation - Page Load");
        Sitecore.Diagnostics.Profiler.StartOperation("Main Navigation - Page Load");
        LoadMenu();
        Sitecore.Diagnostics.Profiler.EndOperation("Main Navigation - Page Load");

        // microsites are small and have no need for search.
        if (SiteConfiguration.IsMicrosite())
        {
          txtSearch.Visible = false;
        }
      }

      private void LoadMenu()
      {
        Item presentation = SiteConfiguration.GetPresentationSettingsItem();
        if (presentation != null && presentation["Main Menu Type"] == "Inverse") navbar.Attributes.Add("class", "navbar navbar-inverse");
        
        // Set the page logo
        if (presentation["Logo Location"] == "Navigation Bar")
        {
          Logo.Item = presentation;
          BrandLink.CssClass = "brand logobrand";
          BrandLink.NavigateUrl = LinkManager.GetItemUrl(SiteConfiguration.GetHomeItem());
        }
        else
        {
          BrandLink.Text = GetDictionaryText("navigate");
          BrandLink.NavigateUrl = "#";
          Logo.Visible = false;
        }
        

        HomeItem = SiteConfiguration.GetHomeItem();
        List<Item> nodes = new List<Item>();
        if (HomeItem["Show Item In Menu"] == "1") nodes.Add(HomeItem);
        foreach (Item i in HomeItem.Children)
        {
          if (SiteConfiguration.DoesItemExistInCurrentLanguage(i) && i["Show Item In Menu"] == "1") { nodes.Add(i); }
        }
        rptDropDownMenu.DataSource = nodes;
        rptDropDownMenu.DataBind();
      }

      protected void rptDropDownMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
      {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          Item node = (Item)e.Item.DataItem;
          {
            HyperLink MenuLink = (HyperLink)e.Item.FindControl("MenuLink");
            Literal MenuText = (Literal)e.Item.FindControl("MenuText");
            HtmlControl MenuLi = (HtmlControl)e.Item.FindControl("MenuLi");

            if (MenuLink != null && MenuText != null)
            {
              MenuText.Text = node["Menu Title"];
              MenuLink.NavigateUrl = LinkManager.GetItemUrl(node);
              if (node.ID == Sitecore.Context.Item.ID) { MenuLi.Attributes.Add("class", "active"); }

              if (node["Show Children In Menu"] == "1" && node.HasChildren && node.Parent.ID == HomeItem.ID)
              {
                MenuLi.Attributes.Add("class", "dropdown");
                MenuLink.Attributes.Add("class", "dropdown-toggle");
                MenuLink.Attributes.Add("data-toggle", "dropdown");
                MenuText.Text += "  <b class=\"caret\"></b>";
              
                PlaceHolder phSubTree = (PlaceHolder)e.Item.FindControl("phSubMenu");

                List<Item> nodes = new List<Item>();
                foreach (Item i in node.Children)
                {
                  if (SiteConfiguration.DoesItemExistInCurrentLanguage(i) && i["Show Item In Menu"] == "1") { nodes.Add(i); }
                }

                Repeater rpt = new Repeater();
                rpt.DataSource = nodes;
                rpt.HeaderTemplate = new TopBarRecursiveRepeaterTemplate(ListItemType.Header);
                rpt.ItemTemplate = rptDropDownMenu.ItemTemplate;
                rpt.FooterTemplate = new TopBarRecursiveRepeaterTemplate(ListItemType.Footer);
                rpt.ItemDataBound += new RepeaterItemEventHandler(rptDropDownMenu_ItemDataBound);
                phSubTree.Controls.Add(rpt);
                rpt.DataBind();
              }
            }
          }
        }
      }

      protected void txt_Search_OnTextChanged(object sender, EventArgs e)
      {       
        Session["Search"] = txtSearch.Text;
        Response.Redirect(LinkManager.GetItemUrl(SiteConfiguration.GetSearchItem()), true);
      }
  }
}