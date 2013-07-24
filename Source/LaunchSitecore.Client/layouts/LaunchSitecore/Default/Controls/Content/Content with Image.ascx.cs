namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content
{
    using System;
    using Sitecore.Links;
    using Sitecore.Data.Items;

    public partial class Content_with_Image : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            Item calltoactionitem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item["Call to Action Link"]);
            if (calltoactionitem != null)
                calltoaction.NavigateUrl = LinkManager.GetItemUrl(calltoactionitem);
        }
    }
}