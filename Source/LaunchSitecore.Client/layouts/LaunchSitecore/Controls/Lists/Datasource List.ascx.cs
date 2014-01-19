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
  public partial class Datasource_List : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      /*
         Populate two ways:
        1. Children of Datasource
        2. Children of Current
      */
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
      if (e.Item.ItemType == ListItemType.Header)
      {
        Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");
        if (DataSourceItemOrCurrentItem.Fields["Menu Title"] != null) SectionTitle.Text = DataSourceItemOrCurrentItem.Fields["Menu Title"].Value;        
        else if (DataSourceItemOrCurrentItem.Fields["Title"] != null) SectionTitle.Text = DataSourceItemOrCurrentItem.Fields["Title"].Value;        
      }

      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;

        HyperLink LinkTo = (HyperLink)e.Item.FindControl("LinkTo");
        FieldRenderer Title = (FieldRenderer)e.Item.FindControl("Title");

        if (LinkTo != null && Title != null)
        {
          LinkTo.NavigateUrl = LinkManager.GetItemUrl(node);
          Title.Item = node;
        }
      }
    }
  }
}