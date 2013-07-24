using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(LaunchSitecore.App_Start.GlassWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(LaunchSitecore.App_Start.GlassWebCommon), "Stop")]

namespace Sitecore.Mazda.Client.App_Start
{
    public class GlassWebCommon
    {
        public static void Start()
        {
            var loader = new Glass.Sitecore.Mapper.Configuration.Attributes.AttributeConfigurationLoader(
           "LaunchContent,  LaunchContent");

            var context = new Glass.Sitecore.Mapper.Context(loader);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
        }
    }
}