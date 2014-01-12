using LaunchSitecore.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{
  public partial class Child_List : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
  {
    private void Page_Load(object sender, EventArgs e)
    {           
        rptItems.DataSource = Sitecore.Context.Item.GetChildrenForCurrentLanguage();
        rptItems.DataBind();
    }

    protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;
        {
          HyperLink ItemLink = (HyperLink)e.Item.FindControl("ItemLink");
          FieldRenderer ItemName = (FieldRenderer)e.Item.FindControl("ItemName");
          FieldRenderer ItemAbstract = (FieldRenderer)e.Item.FindControl("ItemAbstract");

          if (ItemLink != null && ItemName != null && ItemAbstract != null)
          {
            ItemLink.NavigateUrl = LinkManager.GetItemUrl(node);
            ItemName.Item = node;
            ItemAbstract.Item = node;
          }
        }
      }
    }
  }
}