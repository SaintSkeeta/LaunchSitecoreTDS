using HedgehogDevelopment.SitecoreProject.PackageInstallPostProcessor.Contracts;
using Sitecore.Data;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HedgehogDevelopment.TDS.CustomExtensions.PostBuildProcessors
{
    public class SmartPublishMasterToTargetDB : IPostDeployAction
    {
        public void RunPostDeployAction(XDocument deployedItems, IPostDeployActionHost host, string parameter)
        {
            var databases = this.GetDatabases(parameter);
            foreach (string targetDatabase in databases)
            {

                host.LogMessage("Smart publishing master to " + targetDatabase);
                PublishManager.PublishSmart(Sitecore.Data.Database.GetDatabase("master"),
                                            new[] { Sitecore.Data.Database.GetDatabase(targetDatabase.Trim()) },
                                            new[] { LanguageManager.GetLanguage("en") });
            }

        }

        private string[] GetDatabases(string parameters)
        {
            if (string.IsNullOrEmpty(parameters))
            {
                throw new System.InvalidOperationException("Please specify comma separated databases in the parameter setting.");
            }

            return parameters.Split(new char[]
            {
                ','
            }, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
