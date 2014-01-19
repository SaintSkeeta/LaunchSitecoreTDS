using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Collections;
using System.Collections.Generic;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Lists
{
  public partial class Icon_and_Title_List : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      /* Populate two ways:
        1. Children of Datasource
        2. Children of Current */
      List<Item> items = new List<Item>();
      foreach (Item item in DataSourceItemOrCurrentItem.Children)
      {
        if (SiteConfiguration.DoesItemExistInCurrentLanguage(item)) items.Add(item);
      }

      if (items.Count > 0)
      {
        rptList.DataSource = items;
        rptList.DataBind();
      }
      else
      {
        if (IsPageEditorEditing)
        {
          WriteAlert("list is empty");
        }
      }
    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;

        HyperLink LinkTo1 = (HyperLink)e.Item.FindControl("LinkTo1");
        FieldRenderer Icon = (FieldRenderer)e.Item.FindControl("Icon");
        HyperLink LinkTo2 = (HyperLink)e.Item.FindControl("LinkTo2");        
        FieldRenderer Title = (FieldRenderer)e.Item.FindControl("Title");
        FieldRenderer Abstract = (FieldRenderer)e.Item.FindControl("Abstract");

        if (LinkTo1 != null && Icon != null && LinkTo2 != null && Title != null && Abstract != null)
        {
          LinkTo1.NavigateUrl = LinkManager.GetItemUrl(node);
          Icon.Item = node;
          LinkTo2.NavigateUrl = LinkManager.GetItemUrl(node);
          Title.Item = node;
          Abstract.Item = node;
          if (node.Template.Key == "term") Abstract.FieldName = "Definition"; else Abstract.FieldName = "Abstract";
        }
      }
    }
  }
}