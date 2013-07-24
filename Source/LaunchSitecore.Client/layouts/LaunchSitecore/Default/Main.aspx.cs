using System;
using System.Web;
using System.Web.UI;
using LaunchSitecore.Configuration;
using System.Text;

namespace LaunchSitecore.layouts.LaunchSitecore.Default
{
    public partial class Main : Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {           
            Response.AddHeader("Vary", "User-Agent");
            Logo.Item = SiteConfiguration.GetPresentationSettingsItem();
            if (!Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging)
            {
                DMSViewer.Visible = false;
            }
            else
            {
                // we don't need these jquery controls unless we are on the published site.
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                StringBuilder cstext = new StringBuilder();
                cstext.Append("<script type=\"text/javascript\">");
                cstext.Append("var $jq = jQuery.noConflict();");
                cstext.Append("$jq(document).ready(function () {");
                cstext.Append("$jq('#foldtarget').fold();");
                cstext.Append("$jq(\".favorties\").colorbox({ inline: true, width: \"50%\" });");
                cstext.Append("$jq(\".version\").colorbox({ inline: true, width: \"560px\" }); ");
                cstext.Append(" });");
                cstext.Append("</script>");
                cs.RegisterClientScriptBlock(cstype, "InitializeControls", cstext.ToString());            
            }
        }        
    }
}
