using Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CreateConcrete;
using Hedgehog.ZeroDeploy.Contracts.Server;
using Glass.Mapper.Pipelines.ObjectConstruction;

/********************************************************************\
* DISCLAIMER:                                                        *
*                                                                    *
* The code in this module is provided as-is and is an example of how *
* to make an ORM like Glass Mapper work with ZeroDeploy Developer.   *
*                                                                    *   
\********************************************************************/

namespace Hedgehog.ZeroDeploySupport.Glass.Pipelines.ObjectConstructionFactory
{
    public class ZeroDeployCreateConcreteTask : CreateConcreteTask
    {
        ITypeCache _typeCache;

        /// <summary>
        /// New constructor that takes a ZeroDeploy type cache. This allows the create to return a class from ZeroDeploy
        /// </summary>
        /// <param name="typeCache"></param>
        public ZeroDeployCreateConcreteTask(ITypeCache typeCache)
        {
            _typeCache = typeCache;
        }

        /// <summary>
        /// Override the default functionality for creating objects to allow the object to be created from a type in the ZeroDeploy type cache.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override object CreateObject(ObjectConstructionArgs args)
        {
            string typeFullName = args.AbstractTypeCreationContext.RequestedType.FullName;

            //See if ZeroDeploy knows about the object and return the type if it does
            if (_typeCache.GetCachedType(typeFullName) != null)
            {
                args.AbstractTypeCreationContext.RequestedType = _typeCache.GetCachedType(typeFullName);
            }

            typeFullName = args.Configuration.Type.FullName;

            //See if ZeroDeploy knows about the object and return the type if it does
            if (_typeCache.GetCachedType(typeFullName) != null)
            {
                args.Configuration.Type = _typeCache.GetCachedType(typeFullName);
            }

            //Use the default implementation if ZeroDeploy doesn't know about the object.
            return base.CreateObject(args);
        }
    }
}
