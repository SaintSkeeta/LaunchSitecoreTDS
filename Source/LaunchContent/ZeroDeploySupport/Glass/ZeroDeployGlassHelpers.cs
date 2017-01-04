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
using Glass.Mapper.Sc.Pipelines.Response;

namespace Hedgehog.ZeroDeploySupport.Glass
{
#if !GLASS_4_2 && !GLASS_4_3
#error Please select the version of glass you are using by addin the GLASS_4_2 or GLASS_4_3 constant to the project 'Build' property tab.
#endif
    public static class ZeroDeployGlassHelpers
    {
        public static void RegisterAssemblyWithGlass(Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name;

            SitecoreContext ctx = new SitecoreContext();

            List<Type> typesToRemove = new List<Type>(from t in ctx.GlassContext.TypeConfigurations.Keys
                                                      where t.Assembly.GetName().Name == assemblyName
                                                      select t);

            //Clear out any types in the type configuration collection that were in the previous version of the assembly
            foreach (Type typeToRemove in typesToRemove)
            {
                AbstractTypeConfiguration cfg;

                ctx.GlassContext.TypeConfigurations.TryRemove(typeToRemove, out cfg);
            }

            ctx.GlassContext.Load(new IConfigurationLoader[] {
                new ZeroDeployAttributeConfigurationLoader(assembly),
            });

        }

        public static void GlassZeroDeployInitialization()
        {
            IEventManager eventManager = ServiceLocator.ServiceProvider.GetService<IEventManager>();
            ITypeCache typeCache = ServiceLocator.ServiceProvider.GetService<ITypeCache>();

            SitecoreContext ctx = new SitecoreContext();

            //Disable lambda caching on pages
            ctx.Config.UseGlassHtmlLambdaCache = false;

            if ((from t in ctx.GlassContext.DependencyResolver.ConfigurationResolverFactory.GetItems()
                 where t.GetType() == typeof(TemplateInferredTypeTask)
                 select t).Any())
            {
                ctx.GlassContext.DependencyResolver.ConfigurationResolverFactory.Replace<TemplateInferredTypeTask, ZeroDeployTemplateInferredTypeTask>(() => new ZeroDeployTemplateInferredTypeTask(eventManager));
            }

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
