namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{
    using System;

    public partial class Sibling_Article_List : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            siblinglist.DataSource = Sitecore.Context.Item.Parent.Paths.FullPath;
        }
    }
}