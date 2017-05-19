using Glass.Mapper.Configuration;
using Glass.Mapper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/********************************************************************\
* DISCLAIMER:                                                        *
*                                                                    *
* The code in this module is provided as-is and is an example of how *
* to make an ORM like Glass Mapper work with ZeroDeploy Developer.   *
*                                                                    *   
\********************************************************************/

namespace Hedgehog.ZeroDeploySupport.Glass
{
    internal class ZeroDeployAttributeConfigurationLoader : AttributeConfigurationLoader, IConfigurationLoader
    {
        Assembly _assembly;
        public ZeroDeployAttributeConfigurationLoader(Assembly assembly) : base(new string[] { })
        {
            _assembly = assembly;
        }

        public new IEnumerable<AbstractTypeConfiguration> Load()
        {
            return this.LoadFromAssembly(_assembly);
        }
    }
}
