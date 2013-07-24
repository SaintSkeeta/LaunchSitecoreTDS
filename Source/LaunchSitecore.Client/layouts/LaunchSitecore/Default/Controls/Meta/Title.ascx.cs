using System;
using LaunchSitecore.Configuration;
using Sitecore.Data.Items;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Meta
{
    public partial class Title : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item siteSettings = SiteConfiguration.GetSiteSettingsItem();
            Item home = SiteConfiguration.GetHomeItem();
            Item currentItem = Sitecore.Context.Item;

            if (Sitecore.Context.Item.ID == home.ID || Sitecore.Context.Item.ParentID == home.ID)
            {
                pagetitle.Text = String.Format(siteSettings["Page Title for Home and Site Sections"], currentItem["Menu Title"]);
            }
            else
            {
                Item section = currentItem.Parent;
                while (section.ParentID != home.ID)
                {
                    section = section.Parent;
                }
                pagetitle.Text = String.Format(siteSettings["Page Title for Lower Pages"], currentItem["Menu Title"], section["Menu Title"]);
            }
        }
    }
}