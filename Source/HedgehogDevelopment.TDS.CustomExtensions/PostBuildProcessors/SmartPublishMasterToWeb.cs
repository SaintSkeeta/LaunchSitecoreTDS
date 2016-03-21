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
    public class SmartPublishMasterToWeb : IPostDeployAction
    {
        public void RunPostDeployAction(XDocument deployedItems, IPostDeployActionHost host, string parameter)
        {

            host.LogMessage("Smart publishing master to web");
            PublishManager.PublishSmart(Sitecore.Data.Database.GetDatabase("master"), 
                                        new [] { Sitecore.Data.Database.GetDatabase("web") }, 
                                        new [] { LanguageManager.GetLanguage("en") });

        }
    }
}
