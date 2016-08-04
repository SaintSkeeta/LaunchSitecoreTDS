using HedgehogDevelopment.SitecoreProject.PackageInstallPostProcessor.Contracts;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HedgehogDevelopment.TDS.CustomExtensions.PostBuildProcessors
{
    public class RebuildLinkDatabase : IPostDeployAction
    {
        public void RunPostDeployAction(XDocument deployedItems, IPostDeployActionHost host, string parameter)
        {
            var databases = this.GetDatabases(parameter);
            foreach (string databaseName in databases)
            {
                Database database = Sitecore.Data.Database.GetDatabase(databaseName.Trim());
                if (database == null)
                {
                    host.LogMessage("Database with the name '{0}' in null", databaseName);
                    continue;
                }
                Sitecore.Globals.LinkDatabase.Rebuild(database);
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
