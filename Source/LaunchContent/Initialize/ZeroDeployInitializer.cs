using Hedgehog.ZeroDeploy.Client;
using Hedgehog.ZeroDeploySupport.Glass;
using System.Reflection;

namespace LaunchContent.Initialize
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
