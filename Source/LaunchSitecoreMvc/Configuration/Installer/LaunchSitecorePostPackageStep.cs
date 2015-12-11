using System.Collections.Specialized;
using LaunchSitecore.Configuration.Security;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.Install.Framework;

// Summary: This code is used to peform specific post steps for the Launch Sitecore Site
namespace LaunchSitecore.Configuration.Installer
{
    public class LaunchSitecorePostPackageStep : IPostStep
    {
        public void Run(ITaskOutput output, NameValueCollection metaData)
        {
          // Create the standard users
          CreateSecurityAccounts.CreateAccounts();
          
          // Rebuild the core and master indexes
          IndexCustodian.FullRebuild(ContentSearchManager.GetIndex("sitecore_core_index"), true);
          IndexCustodian.FullRebuild(ContentSearchManager.GetIndex("sitecore_master_index"), true);
        }
    }
}

