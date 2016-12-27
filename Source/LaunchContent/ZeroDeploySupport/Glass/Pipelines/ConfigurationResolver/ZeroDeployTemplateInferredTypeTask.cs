using Glass.Mapper;
using Glass.Mapper.Pipelines.ConfigurationResolver;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Sitecore.Data;
using System;
using System.Collections.Concurrent;
using System.Linq;
using Hedgehog.ZeroDeploy.Contracts.Server;
using Glass.Mapper.Sc.Pipelines.ConfigurationResolver;

namespace Hedgehog.ZeroDeploySupport.Glass.Pipelines.ConfigurationResolver
{
#if GLASS_4_2
    public class ZeroDeployTemplateInferredTypeTask : IConfigurationResolverTask
#else 
#if GLASS_4_3
    public class ZeroDeployTemplateInferredTypeTask : TemplateInferredTypeTask
#else
#error Please select the version of glass you are using by addin the GLASS_4_2 or GLASS_4_3 constant to the project 'Build' property tab.
    public class ZeroDeployTemplateInferredTypeTask : IConfigurationResolverTask
#endif
#endif
    {
        static ConcurrentDictionary<Tuple<Context, Type, ID>, SitecoreTypeConfiguration> _inferredCache = new ConcurrentDictionary<Tuple<Context, Type, ID>, SitecoreTypeConfiguration>();
        static IEventManager _eventManager;

        public ZeroDeployTemplateInferredTypeTask(IEventManager eventManager)
        {
#if GLASS_4_3
            Name = "ZeroDeployTemplateInferredTypeTask";
#endif
            if (_eventManager == null)
            {
                _eventManager = eventManager;

                _eventManager.OnAssemblyReloaded += EventManager_OnAssemblyReloaded;
            }
        }

        private void EventManager_OnAssemblyReloaded(object sender, AssemblyReloadedEventArgs e)
        {
            _inferredCache.Clear();
        }

#region IPipelineTask<ConfigurationResolverArgs> Members

        /// <summary>
        /// The execute method is lifted right out of the Glass source code. 
        /// This is needed because Glass doesn't expose the _inferredCache objec, so we can't clear it when assemblies are re-loaded.
        /// </summary>
        /// <param name="args">The args.</param>
#if GLASS_4_2
        public void Execute(ConfigurationResolverArgs args)
        {
            if (args.Result == null && args.AbstractTypeCreationContext.InferType)
            {
                var scContext = args.AbstractTypeCreationContext as SitecoreTypeCreationContext;

                var requestedType = scContext.RequestedType;
                var item = scContext.Item;
                var templateId = item != null ? item.TemplateID : scContext.TemplateId;

                var key = new Tuple<Context, Type, ID>(args.Context, requestedType, templateId);
                if (_inferredCache.ContainsKey(key))
                {
                    args.Result = _inferredCache[key];
                }
                else
                {
                    var configs = args.Context.TypeConfigurations.Select(x => x.Value as SitecoreTypeConfiguration);

                    var types = configs.Where(x => x.TemplateId == templateId);
                    if (types.Any())
                    {
                        args.Result = types.FirstOrDefault(x => requestedType.IsAssignableFrom(x.Type));
                        if (!_inferredCache.TryAdd(key, args.Result as SitecoreTypeConfiguration))
                        {
                            //TODO: some logging
                        }
                    }
                }
            }
        }
#else
#if GLASS_4_3
        public override void Execute(ConfigurationResolverArgs args)
        {
            if (args.Result == null && args.AbstractTypeCreationContext.InferType)
            {
                var scContext = args.AbstractTypeCreationContext as SitecoreTypeCreationContext;

                var requestedType = scContext.RequestedType;
                var item = scContext.Item;
                var templateId = item != null ? item.TemplateID : scContext.TemplateId;

                var key = new Tuple<Context, Type, ID>(args.Context, requestedType, templateId);
                if (_inferredCache.ContainsKey(key))
                {
                    args.Result = _inferredCache[key];
                }
                else
                {
                    var configs = args.Context.TypeConfigurations.Select(x => x.Value as SitecoreTypeConfiguration);

                    var types = configs.Where(x => x.TemplateId == templateId);
                    if (types.Any())
                    {
                        args.Result = types.FirstOrDefault(x => requestedType.IsAssignableFrom(x.Type));
                        if (!_inferredCache.TryAdd(key, args.Result as SitecoreTypeConfiguration))
                        {
                            //TODO: some logging
                        }
                    }
                }
            }

            base.Execute(args);
        }
#else
        public void Execute(ConfigurationResolverArgs args)
        {
        }
#endif
#endif

#endregion

    }
}
