using System;
using Sitecore.Data.Comparers;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using Sitecore.Resources.Media;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using LaunchSitecore.Configuration.SiteUI.Base;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Lists
{
  public partial class Tags : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      MultilistField tags = Sitecore.Context.Item.Fields["__semantics"];
      if (tags != null && tags.GetItems().Length > 0)
      {
        rptTags.DataSource = tags.GetItems();
        rptTags.DataBind();
      }
      else
      {
        if (IsPageEditorEditing)
        {
          WriteAlert("item is not tagged");
        }
      }
    }

    protected void rptTags_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Header)
      {
        Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");        
        SectionTitle.Text = GetDictionaryText("Tags");       
      }

      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;
        {
          LinkButton RelatedLink = (LinkButton)e.Item.FindControl("RelatedLink");
          
          if (RelatedLink != null)
          {
            RelatedLink.CommandArgument = node.ID.ToGuid().ToString("N");
            RelatedLink.Text = node.Name;
          }
        }
      }
    }

    protected void SearchByTag(object sender, EventArgs e)
    {
      Session["Search"] = "*";
      Session["tag"] = ((LinkButton) sender).CommandArgument;
      Response.Redirect(LinkManager.GetItemUrl(SiteConfiguration.GetSearchItem()), true);      
    }   
  }
}