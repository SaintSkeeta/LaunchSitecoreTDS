using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Buckets.Util;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Lists
{
  public partial class Queried_List : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      if (DataSourceItems.Count > 0)
      {
        rptItems.DataSource = DataSourceItems;
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

    protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Header && DataSourceItem != null)
      {
        Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");
        SectionTitle.Text = DataSourceItem["Title"];
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