using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SecurityModel;
using Sitecore.Install.Framework;
using System.Collections.Specialized;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch;
using LaunchSitecore.Configuration.Administration.Security;

// Summary: This code is used to peform specific post steps for the Launch Sitecore Site
namespace LaunchSitecore.Configuration.Administration.Install
{
    public class LaunchSitecorePostPackageStep : IPostStep
    {
        public void Run(ITaskOutput output, NameValueCollection metaData)
        {
          // Create the standard users
          LaunchSitecore.Configuration.Administration.Security.CreateSecurityAccounts.CreateAccounts();

          // Rebuild the core and master indexes
          IndexCustodian.FullRebuild(ContentSearchManager.GetIndex("sitecore_core_index"), true);
          IndexCustodian.FullRebuild(ContentSearchManager.GetIndex("sitecore_master_index"), true);
        }
    }
}

