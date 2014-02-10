using System;
using System.Web;
using System.Web.UI;
using LaunchSitecore.Configuration.SiteUI.Base;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Data.Fields;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default
{
    public partial class Main : SitecorePageLayoutBase
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
          // This page is setting a lot fo the presentation details.  This is due tot he flexible nature of this site.
          Item PresentationSettings = SiteConfiguration.GetPresentationSettingsItem();

          // Set the page logo
          if (PresentationSettings["Logo Location"] == "Header")
          {
            Logo.Item = PresentationSettings;
          }
          else 
          {
            Logo.Visible = false;
            logospan.Visible = false;            
            tertiarynavspan.Attributes.Add("class", "span12");            
          }

          // set the page layout
          out_container.Attributes.Add("class", PresentationSettings["Layout Style"].ToLower().Replace(" ","-"));

          // Show/Hide the top line
          if (PresentationSettings["Show Top Line"] != "1")
            topline.Attributes.Add("class", "top_line_plain");
                    
          // set the background image / color
          if (PresentationSettings["Background Image"] != string.Empty)
          {
            ImageField imgField = ((Sitecore.Data.Fields.ImageField)PresentationSettings.Fields["Background Image"]);            
            mainbody.Style.Add("background-image", MediaManager.GetMediaUrl(imgField.MediaItem));

            if (imgField.MediaItem.Parent.Key == "patterns") mainbody.Attributes.Add("class", "background-pattern");
            else mainbody.Attributes.Add("class", "background-cover");            
          }
          else if (PresentationSettings["Background Color"] != string.Empty)
          {
            mainbody.Style.Add("background-color", PresentationSettings["Background Color"]);
          }

          Copyright.Item = SiteConfiguration.GetSiteSettingsItem();               
        }        
    }
}
