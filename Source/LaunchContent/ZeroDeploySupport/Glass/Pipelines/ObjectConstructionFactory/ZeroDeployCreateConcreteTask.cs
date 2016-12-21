using Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CreateConcrete;
using Hedgehog.ZeroDeploy.Contracts.Server;
using Glass.Mapper.Pipelines.ObjectConstruction;

namespace Hedgehog.ZeroDeploySupport.Glass.Pipelines.ObjectConstructionFactory
{
    public class ZeroDeployCreateConcreteTask : CreateConcreteTask
    {
        ITypeCache _typeCache;
        public ZeroDeployCreateConcreteTask(ITypeCache typeCache)
        {
            _typeCache = typeCache;
        }

        protected override object CreateObject(ObjectConstructionArgs args)
        {
            string typeFullName = args.AbstractTypeCreationContext.RequestedType.FullName;

            if (_typeCache.GetCachedType(typeFullName) != null)
            {
                args.AbstractTypeCreationContext.RequestedType = _typeCache.GetCachedType(typeFullName);
            }

            typeFullName = args.Configuration.Type.FullName;

            if (_typeCache.GetCachedType(typeFullName) != null)
            {
                args.Configuration.Type = _typeCache.GetCachedType(typeFullName);
            }

            return base.CreateObject(args);
        }
    }
}
