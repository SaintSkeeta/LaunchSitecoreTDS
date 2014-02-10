using System.Web.UI.WebControls;
using LaunchSitecore.Configuration.AuthoringExperience.PageEditor;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using Sitecore.ContentSearch;
using System.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Buckets.Util;
using System.Collections.Generic;

namespace LaunchSitecore.Configuration.SiteUI.Base
{
  public class SitecoreSingleItemUserControl : SitecoreUserControlBase
  {
    /// <summary>
    /// Automatically resets the Context item to the specified datasource if not null
    /// </summary>
    /// <param name="writer"></param>
    protected void WriteAlertsIfNeeded()
    {
      if (IsDataSourceItemNull)
      {
        if (IsPageEditorEditing)
        {          
          WriteAlert("datasource is null");
        }
      }
      else if (!SiteConfiguration.DoesItemExistInCurrentLanguage(DataSourceItem))
      {
        if (IsPageEditorEditing)
        {
          WriteAlert("no version in current language");
        }
      }      
    }

    protected void HideIfNoVersionUnlessPageEditing()
    {
      if (IsDataSourceItemNull || !SiteConfiguration.DoesItemExistInCurrentLanguage(DataSourceItem))
      {
        if (!IsPageEditorEditing)
        {
          this.Visible = false;
        }
      }      
    }
  }
}