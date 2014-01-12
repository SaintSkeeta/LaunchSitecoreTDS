using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SecurityModel;
using Sitecore.Install.Framework;
using System.Collections.Specialized;
using LaunchSitecore.Configuration.Security;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch;


// Summary:        This code is used to peform specific post steps for the Launch Sitecore Site
namespace LaunchSitecore.Configuration.Install
{
    public class LaunchSitecorePostPackageStep : IPostStep
    {
        public void Run(ITaskOutput output, NameValueCollection metaData)
        {
            ResetUser.ResetUserAccount("sitecore\\Audrey", "a");
            ResetUser.ResetUserAccount("sitecore\\Bill", "b");
            ResetUser.ResetUserAccount("sitecore\\Lonnie", "l");

            // Rebuild the core and master indexes
            IndexCustodian.FullRebuild(ContentSearchManager.GetIndex("sitecore_core_index"), true);
            IndexCustodian.FullRebuild(ContentSearchManager.GetIndex("sitecore_master_index"), true);
        }
    }
}

