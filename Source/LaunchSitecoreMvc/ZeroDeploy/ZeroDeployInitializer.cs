using Hedgehog.ZeroDeploy.Client;
using Hedgehog.ZeroDeploy.Glass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LaunchSitecore.ZeroDeploy
{
    public class ZeroDeployInitializer : IZeroDeployInitializer
    {
        public void InitializeZeroDeploy()
        {
            ZeroDeployGlassHelpers.GlassZeroDeployInitialization();

            ZeroDeployGlassHelpers.RegisterAssemblyWithGlass(Assembly.GetExecutingAssembly());
        }
    }
}