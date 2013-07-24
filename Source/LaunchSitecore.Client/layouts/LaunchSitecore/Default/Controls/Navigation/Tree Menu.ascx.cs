using System;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.Links;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using LaunchSitecore.Configuration;
using System.Collections.Generic;
using LaunchSitecore.Configuration.Presentation;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation
{
    public partial class TreeMenu : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
   {
      private void Page_Load(object sender, EventArgs e)
      {   
          // The tree menu is basically the secondary navigation for the site.
          // The datasource needs to be one level off the home node.
          Item home = SiteConfiguration.GetHomeItem();
          Item dataSource = Sitecore.Context.Item;
          if (home.ID != dataSource.ID)  // if on the home node, just use it
          {
              while (dataSource.ParentID != home.ID)
              {
                  dataSource = dataSource.Parent;
              }
          }
          
          // now we can populate the tree.
          List<Item> nodes = new List<Item>();
          foreach (Item i in dataSource.Children)
          {
              if (i.Versions.Count > 0 && i["Hide Item from Secondary Menu"] != "1") { nodes.Add(i); }
          }                    
          rptTree.DataSource = nodes;
          rptTree.DataBind();
      }

      protected void rptTree_ItemDataBound(object sender, RepeaterItemEventArgs e)
      {
         if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
         {
            Item node = (Item)e.Item.DataItem;           
            {
               HyperLink MenuLink = (HyperLink)e.Item.FindControl("MenuLink");               
               HtmlControl liwrapper = (HtmlControl)e.Item.FindControl("liwrapper");

               if (MenuLink != null)
               {
                  MenuLink.NavigateUrl = LinkManager.GetItemUrl(node);
                  MenuLink.Text = node["Menu Title"];

                  // determine if the current item is a descendant
                  if (Sitecore.Context.Item.ID == node.ID ||
                      node.Axes.SelectItems(String.Format(".//*[@@id = '{0}']", Sitecore.Context.Item.ID)) != null) // do not compare nodes as it is faster to compare ids.
                  {
                      liwrapper.Attributes.Add("class", "selected");

                      // now load the children since this is the selected node
                      if (node.HasChildren)
                      {
                          PlaceHolder phSubTree = (PlaceHolder)e.Item.FindControl("phSubTree");
                          Repeater rpt = new Repeater();
                          List<Item> nodes = new List<Item>();
                          foreach (Item i in node.Children)
                          {
                              if (i.Versions.Count > 0 && i["Hide Item from Secondary Menu"] != "1") { nodes.Add(i); }
                          }                    
                          rpt.DataSource = nodes;
                          rpt.HeaderTemplate = new RecursiveRepeaterTemplate(ListItemType.Header);
                          rpt.ItemTemplate = rptTree.ItemTemplate;
                          rpt.FooterTemplate = new RecursiveRepeaterTemplate(ListItemType.Footer);
                          rpt.ItemDataBound += new RepeaterItemEventHandler(rptTree_ItemDataBound);
                          phSubTree.Controls.Add(rpt);
                          rpt.DataBind();
                      }
                  }
               }
            }
         }
      }
   }
}
