using Glass.Mapper.Configuration;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Pipelines.ConfigurationResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hedgehog.ZeroDeploySupport.Glass.Pipelines.ConfigurationResolver;
using Hedgehog.ZeroDeploy.Contracts.Server;
using Sitecore.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CreateConcrete;
using Hedgehog.ZeroDeploySupport.Glass.Pipelines.ObjectConstructionFactory;
#if GLASS_4_3
using Glass.Mapper.Sc.Pipelines.Response;
#endif 

/********************************************************************\
* DISCLAIMER:                                                        *
*                                                                    *
* The code in this module is provided as-is and is an example of how *
* to make an ORM like Glass Mapper work with ZeroDeploy Developer.   *
*                                                                    *   
\********************************************************************/

namespace Hedgehog.ZeroDeploySupport.Glass
{
#if !GLASS_4_2 && !GLASS_4_3
#error Please select the version of glass you are using by addin the GLASS_4_2 or GLASS_4_3 constant to the project 'Build' property tab.
#endif
    public static class ZeroDeployGlassHelpers
    {
        /// <summary>
        /// Registers the specified assembly with Glass. This would usually be performed in an application start function,
        /// but since the assembly needs to be re-registered every time ZeroDeploy re-loads the assembly, it needs to remove
        /// old type mappings and replace them with new ones.
        /// </summary>
        /// <param name="assembly"></param>
        public static void RegisterAssemblyWithGlass(Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name;

            SitecoreContext ctx = new SitecoreContext();

            //Finsd all type mappings from previous versions of the assembly
            List<Type> typesToRemove = new List<Type>(from t in ctx.GlassContext.TypeConfigurations.Keys
                                                      where t.Assembly.GetName().Name == assemblyName
                                                      select t);

            //Clear out any types in the type configuration collection that were in the previous version of the assembly
            foreach (Type typeToRemove in typesToRemove)
            {
                AbstractTypeConfiguration cfg;

                ctx.GlassContext.TypeConfigurations.TryRemove(typeToRemove, out cfg);
            }

            //Call Glass to re-load the assembly into the internal map
            ctx.GlassContext.Load(new IConfigurationLoader[] {
                new ZeroDeployAttributeConfigurationLoader(assembly),
            });

        }

        /// <summary>
        /// Glass Mapper maintains a number of internal caches to improve the performance of the ORM. These
        /// caches could potentially return old versions of classes from previous versions of the assembly
        /// </summary>
        public static void GlassZeroDeployInitialization()
        {
            IEventManager eventManager = ServiceLocator.ServiceProvider.GetService<IEventManager>();
            ITypeCache typeCache = ServiceLocator.ServiceProvider.GetService<ITypeCache>();

            SitecoreContext ctx = new SitecoreContext();

            //Disable lambda caching on pages to prevent lambda caches from returning obsolete classes
            ctx.Config.UseGlassHtmlLambdaCache = false;

            //See if the default configuration resolver is installed and replace it with a ZeroDeploy aware resolver
            if ((from t in ctx.GlassContext.DependencyResolver.ConfigurationResolverFactory.GetItems()
                 where t.GetType() == typeof(TemplateInferredTypeTask)
                 select t).Any())
            {
                ctx.GlassContext.DependencyResolver.ConfigurationResolverFactory.Replace<TemplateInferredTypeTask, ZeroDeployTemplateInferredTypeTask>(() => new ZeroDeployTemplateInferredTypeTask(eventManager));
            }

            //See if the default object construction factory is present and replace it with the ZeroDeploy aware one
            if ((from t in ctx.GlassContext.DependencyResolver.ObjectConstructionFactory.GetItems()
                 where t.GetType() == typeof(CreateConcreteTask)
                 select t).Any())
            {
                ctx.GlassContext.DependencyResolver.ObjectConstructionFactory.Replace<CreateConcreteTask, ZeroDeployCreateConcreteTask>(() => new ZeroDeployCreateConcreteTask(typeCache));
            }

#if GLASS_4_3
            //Swap back to build model resolver. Not as fast, but works with ZeroDeploy
            //You must have a reference to Glass.Mapper.sc.Mvc.dll for this to compile.
            if (GetModelFromView.ViewTypeResolver is RegexViewTypeResolver)
            {
                GetModelFromView.ViewTypeResolver = new BuildManagerViewTypeResolver();
            }
#endif
        }
    }
}
