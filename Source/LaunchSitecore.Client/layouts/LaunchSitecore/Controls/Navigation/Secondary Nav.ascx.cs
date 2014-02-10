using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation
{
  public partial class Secondary_Nav : SitecoreUserControlBase
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

      MenuHeader.Item = dataSource;

      // now we can populate the tree.
      List<Item> nodes = new List<Item>();
      foreach (Item i in dataSource.Children)
      {
        if (SiteConfiguration.DoesItemExistInCurrentLanguage(i) && i["Show Item in Secondary Menu"] == "1") { nodes.Add(i); }
      }

      if (nodes.Count > 0)
      {
        rptTree.DataSource = nodes;
        rptTree.DataBind();
      }
      else
      {
        menuWrapper.Visible = false;
        if (IsPageEditorEditing)
        {
          WriteAlert("list is empty");          
        }
      }      
    }

    protected void rptTree_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;
        {
          HyperLink MenuLink = (HyperLink)e.Item.FindControl("MenuLink");
          FieldRenderer MenuText = (FieldRenderer)e.Item.FindControl("MenuText");

          if (MenuLink != null && MenuText != null)
          {
            MenuLink.NavigateUrl = LinkManager.GetItemUrl(node);
            MenuText.Item = node;

            // determine if the current item is a descendant
            if (Sitecore.Context.Item.ID == node.ID || node.Axes.SelectItems(String.Format(".//*[@@id = '{0}']", Sitecore.Context.Item.ID)) != null) // do not compare nodes as it is faster to compare ids.
            {

              // apply active state to the current item.
              if (Sitecore.Context.Item.ID == node.ID) { MenuLink.Attributes.Add("class", "active"); }

              // now load the children since this is the selected node
              if (node.HasChildren)
              {
                PlaceHolder phSubTree = (PlaceHolder)e.Item.FindControl("phSubTree");
                Repeater rpt = new Repeater();
                List<Item> nodes = new List<Item>();
                foreach (Item i in node.Children)
                {
                  if (SiteConfiguration.DoesItemExistInCurrentLanguage(i) && i["Show Item in Secondary Menu"] == "1") { nodes.Add(i); }
                }
                rpt.DataSource = nodes;
                rpt.HeaderTemplate = rptTree.HeaderTemplate;
                rpt.ItemTemplate = rptTree.ItemTemplate;
                rpt.FooterTemplate = rptTree.FooterTemplate;
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
