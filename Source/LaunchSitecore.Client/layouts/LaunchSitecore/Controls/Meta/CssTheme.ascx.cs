using System;
using System.Web.UI.HtmlControls;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Meta
{
    public partial class CssTheme : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            HtmlLink css = new HtmlLink();
            css.Href = String.Format("/assets/css/colors/color_scheme_{0}.css", SiteConfiguration.GetPresentationSettingsItem()["Site Color"]).ToLower();
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            css.Attributes["media"] = "all";
            litCssHolder.Controls.Add(css);
        }
    }
}