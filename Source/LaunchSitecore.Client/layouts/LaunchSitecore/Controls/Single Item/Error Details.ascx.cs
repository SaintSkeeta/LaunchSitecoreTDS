using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.SiteUI.Base;
using System;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item
{
  public partial class Error_Details : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      ErrorHeading.Text = GetDictionaryText("Server Error in Application");

      if (SiteConfiguration.GetSiteSettingsItem()["Show Error Details on Error Page"] == "1")
      {
        ExceptionMessageHeading.Text = GetDictionaryText("Message");
        StackTraceHeading.Text = GetDictionaryText("Stack Trace");
        InnerExceptionHeading.Text = GetDictionaryText("Inner Exception");
        InnerExceptionMessageHeading.Text = GetDictionaryText("Message");
        InnerStackTraceHeading.Text = GetDictionaryText("Stack Trace");

        if (Session["LastException"] != null)
        {
          Exception exc = (Exception)Session["LastException"];

          ExceptionMessage.Text = exc.Message;
          StackTrace.Text = exc.StackTrace.Replace("\r\n", "<br />");

          if (exc.InnerException != null)
          {
            InnerExceptionPanel.Visible = true;
            InnerExceptionMessage.Text = exc.InnerException.Message;
            InnerStackTrace.Text = exc.InnerException.StackTrace.Replace("\r\n", "<br />");
          }
        }
      }

      // Clear the error from the server
      Server.ClearError();
    }
  }
}