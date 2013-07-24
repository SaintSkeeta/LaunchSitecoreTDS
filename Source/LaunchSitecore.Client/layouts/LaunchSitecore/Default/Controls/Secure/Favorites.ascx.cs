using System;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using System.Collections.Generic;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Favorites : System.Web.UI.UserControl
    {
        bool showAbstracts = true;

        private void Page_PreRender(object sender, EventArgs e)
        {
            if (Sitecore.Context.User.IsAuthenticated)
            {
                // we need to retreive the items list from the rendering paramaters.  Since these
                // are stored as a string, we have to manually split it apart.
                // normally you could use a multilistfield to do this for you.
                List<Item> items = new List<Item>();
                Sitecore.Security.Accounts.User user = Sitecore.Context.User;
                Sitecore.Security.UserProfile profile = user.Profile;
                string ItemIds = profile.GetCustomProperty("Favorites");

                foreach (string itemId in ItemIds.Split('|'))
                {
                    Item item = Sitecore.Context.Database.GetItem(itemId);
                    if (item != null)
                        items.Add(item);
                }

                SectionTitle.Text = SiteConfiguration.GetDictionaryText("Favorites");

                if (items.Count > 0)
                {
                    // we will remove the abstracts so the list is shorter based on the number of items in the list
                    if (items.Count > 5) showAbstracts = false;

                    rptItems.DataSource = items;
                    rptItems.DataBind();
                }
                else
                {
                    showIfEmpty.Text = SiteConfiguration.GetDictionaryText("No Favorites");
                    showIfEmpty.Visible = true;
                }
            }
        }

        protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink ItemLink = (HyperLink)e.Item.FindControl("ItemLink");
                    Literal ItemAbstract = (Literal)e.Item.FindControl("ItemAbstract");

                    if (ItemLink != null && ItemAbstract != null)
                    {
                        ItemLink.NavigateUrl = LinkManager.GetItemUrl(node);
                        ItemLink.Text = node["Title"];
                        if (showAbstracts) ItemAbstract.Text = node["Abstract"];
                    }
                }
            }
        }
    }
}