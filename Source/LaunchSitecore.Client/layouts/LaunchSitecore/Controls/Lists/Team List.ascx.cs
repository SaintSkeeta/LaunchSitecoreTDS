using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Collections;

using System.Linq;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Lists
{
  public partial class Team_List : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      Item team = SiteConfiguration.GetTeamItem();

      if (team != null && team.Template.Key == "team section") //TODO: The team list should not show anything unless it is the team section.  This is enforced in page editor using placeholder settings.
      {
        rptList.DataSource = team.Children.ToArray().Where(item => SiteConfiguration.DoesItemExistInCurrentLanguage(item)); 
        rptList.DataBind();
      }
    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;

        HyperLink LinkTo1 = (HyperLink)e.Item.FindControl("LinkTo1");
        FieldRenderer Image = (FieldRenderer)e.Item.FindControl("Image");
        HyperLink LinkTo2 = (HyperLink)e.Item.FindControl("LinkTo2");
        FieldRenderer FullName = (FieldRenderer)e.Item.FindControl("FullName");
        FieldRenderer Title = (FieldRenderer)e.Item.FindControl("Title");
        FieldRenderer Quote = (FieldRenderer)e.Item.FindControl("Quote");
        FieldRenderer Abstract = (FieldRenderer)e.Item.FindControl("Abstract");

        if (LinkTo1 != null && Image != null && LinkTo2 != null && FullName != null && Title != null && Quote != null && Abstract != null)
        {
          LinkTo1.NavigateUrl = LinkManager.GetItemUrl(node);
          Image.Item = node;
          LinkTo2.NavigateUrl = LinkManager.GetItemUrl(node);
          FullName.Item = node;
          Title.Item = node;
          Quote.Item = node;
          Abstract.Item = node;
        }
      }
    }
  }
}