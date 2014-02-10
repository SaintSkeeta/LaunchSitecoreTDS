using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Analytics;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation
{
  public partial class Breadcrumbs : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      if (Sitecore.Context.Item.ID != SiteConfiguration.GetHomeItem().ID)
      {
        List<Item> items = new List<Item>();

        Database currentdb = Sitecore.Context.Database;
        Item temp = Sitecore.Context.Item;

        while (temp.ID != SiteConfiguration.GetHomeItem().ParentID)
        {
          items.Add(temp);
          temp = temp.Parent;
        }

        items.Reverse();
        rptCrumbs.DataSource = items;
        rptCrumbs.DataBind();
      }
    }

    protected void rptCrumbs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item node = (Item)e.Item.DataItem;
        {
          HyperLink CrumbLink = (HyperLink)e.Item.FindControl("CrumbLink");
          FieldRenderer CrumbText = (FieldRenderer)e.Item.FindControl("CrumbText");
          Literal CrumbLiteral = (Literal)e.Item.FindControl("CrumbLiteral");
          HtmlControl liwrapper = (HtmlControl)e.Item.FindControl("liwrapper");

          if (CrumbLink != null && CrumbLiteral != null && liwrapper != null)
          {
            // the first element needs a class to hide the >
            if (node.ID == SiteConfiguration.GetHomeItem().ID) liwrapper.Attributes.Add("class", "home");

            // the current page doesn't need to be a link
            if (node.ID == Sitecore.Context.Item.ID)
            {
              CrumbLiteral.Text = node["Menu Title"];
              CrumbLink.Visible = false;
              CrumbLiteral.Visible = true;
            }
            else
            {
              CrumbText.Item = node;
              CrumbLink.NavigateUrl = LinkManager.GetItemUrl(node);
            }
          }
        }
      }

      if (e.Item.ItemType == ListItemType.Footer)
      {
        LinkButton btnAddtoFavs = (LinkButton)e.Item.FindControl("btnAddtoFavs");
        if (Sitecore.Context.PageMode.IsNormal && Sitecore.Context.User.IsAuthenticated)
        {
          btnAddtoFavs.Visible = true;
          SetButtonText(btnAddtoFavs);
        }
      }
    }

    protected void btnAddtoFavs_Click(object sender, EventArgs e)
    {
      Sitecore.Security.Accounts.User user = Sitecore.Context.User;
      Sitecore.Security.UserProfile profile = user.Profile;
      string favorites = profile.GetCustomProperty("Favorites");

      // determine if we are adding or removing.  
      // We don't know the text of the button because it is managed in the CMS, so we will see it is already a favorite.            
      if (favorites.Contains(Sitecore.Context.Item.ID.ToString()))
      {
        favorites = favorites.Replace(Sitecore.Context.Item.ID.ToString(), String.Empty);
        favorites = favorites.Replace("||", "|"); // when removeing we may leave a double pipe
        if (favorites == "|") { favorites = String.Empty; }
      }
      else // it must be an add
      {
        if (favorites == String.Empty) { favorites = Sitecore.Context.Item.ID.ToString(); }
        else { favorites = favorites + "|" + Sitecore.Context.Item.ID.ToString(); }

        // Capture the goal
        Tracker.CurrentVisit.CurrentPage.Register("Add a Favorite", "[Add a Favorite] : \"" + Sitecore.Context.Item.Name + "\"");
      }

      profile.SetCustomProperty("Favorites", favorites);
      profile.Save();

      SetButtonText(sender as LinkButton);      
    }

    private void SetButtonText(LinkButton button)
    {
      Sitecore.Security.Accounts.User user = Sitecore.Context.User;
      Sitecore.Security.UserProfile profile = user.Profile;
      string favorites = profile.GetCustomProperty("Favorites");

      if (favorites.Contains(Sitecore.Context.Item.ID.ToString()))
      {
        button.Text = GetDictionaryText("Remove from Favorites");
      }
      else
      {
        button.Text = GetDictionaryText("Add to Favorites");
      }
    }
  }
}
