using Hedgehog.ZeroDeploy.Client;
using Hedgehog.ZeroDeploySupport.Glass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LaunchContent.ZeroDeploy
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
