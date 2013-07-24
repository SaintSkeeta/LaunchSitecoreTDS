namespace LaunchSitecore.layouts.MyFirstSite.Controls
{
    using System;
    using System.Web.UI.WebControls;
    using Sitecore.Data.Items;

    public partial class Side_Menu : System.Web.UI.UserControl
    {
        Sitecore.Data.Items.Item home;

        private void Page_Load(object sender, EventArgs e)
        {
            // Add the home link
            string homePath = "/sitecore/content/My First Site Exercise";
            home = Sitecore.Context.Database.GetItem(homePath);                       

            MenuRepeater.DataSource = home.Children;
            MenuRepeater.DataBind();
        }

        protected void Menu_OnItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                HyperLink homeLink = (HyperLink)e.Item.FindControl("homeLink");
                homeLink.Text = home["Title"];
                homeLink.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(home);
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink subLink = (HyperLink)e.Item.FindControl("subLink");
                subLink.Text = ((Item)e.Item.DataItem).Fields["Title"].Value;
                subLink.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl((Item)e.Item.DataItem);                
            }
            
        }
    }
}