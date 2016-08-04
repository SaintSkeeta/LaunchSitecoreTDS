using HedgehogDevelopment.SitecoreProject.PackageInstallPostProcessor.Contracts;
using HedgehogDevelopment.SitecoreProject.PackageInstallPostProcessor.Utils;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HedgehogDevelopment.TDS.CustomExtensions.PostBuildProcessors
{
    public class RebuildContentSearchIndexes : IPostDeployAction
    {
        public void RunPostDeployAction(XDocument deployedItems, IPostDeployActionHost host, string parameter)
        {
            string[] indexNames = this.GetContentSearchIndexes(parameter);
            foreach (var indexName in indexNames)
            {
                var index = ContentSearchManager.GetIndex(indexName.Trim());

                if (index == null)
                {
                    host.LogMessage("The Content Search Index with name {0} supplied does not exist.", indexName);
                    continue;
                }

                host.LogMessage("Rebuilding index {0}...", indexName);
                IndexCustodian.FullRebuild(index, true);
                host.LogMessage("Rebuild of index {0} complete", indexName);
            }
        }

        private string[] GetContentSearchIndexes(string parameters)
        {
            if (string.IsNullOrEmpty(parameters))
            {
                throw new System.InvalidOperationException("Please specify a Sitecore Content Search index in the parameter");
            }

            return parameters.Split(new char[]
            {
                ','
            }, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
