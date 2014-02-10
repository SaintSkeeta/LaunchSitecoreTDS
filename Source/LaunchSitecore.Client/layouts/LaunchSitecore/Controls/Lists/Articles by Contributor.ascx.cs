using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Buckets.Util;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Lists
{
  public partial class Articles_by_Contributor : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      if (Sitecore.Context.Item.Template.Key == "team member")
      {
        // this query will get the articles by the current team member
        // The queried list can also handle this by setting the datasource to a query.
        // The Standard Values can even pass in the id when the item is created.  
        // Example Query: +template:d9019e30f95446ccaa703e928c40b5d0;+location:63ABEE8A4E3841599193D5F0A33AD666;+custom:contributors|$id;
        string query = String.Format("+custom:contributors|{0};+template:d9019e30f95446ccaa703e928c40b5d0;+location:63ABEE8A4E3841599193D5F0A33AD666;", Sitecore.Context.Item.ID.ToString());
        List<Item> items = GetDataSourceItemsFromQuery(query);

        if (items.Count > 0)
        {
          rptItems.DataSource = items;
          rptItems.DataBind();
        }
        else
        {
          if (IsPageEditorEditing)
          {
            WriteAlert("list is empty");
          }
        }
      }
    }

    protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Header)
      {
        Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");
        SectionTitle.Text = GetDictionaryText("Articles");
      }

      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;
        {
          HyperLink ItemLink = (HyperLink)e.Item.FindControl("ItemLink");
          FieldRenderer ItemName = (FieldRenderer)e.Item.FindControl("ItemName");

          if (ItemLink != null && ItemName != null)
          {
            ItemLink.NavigateUrl = LinkManager.GetItemUrl(node);
            ItemName.Item = node;
          }
        }
      }
    }
  }
}