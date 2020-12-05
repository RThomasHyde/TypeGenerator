using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;

namespace RThomasHyde.TypeGenerator
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly List<Assembly> _assemblies;

        public CustomAssemblyLoadContext(List<Assembly> assemblies) : base(isCollectible: true)
        {
            _assemblies = assemblies;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            try
            {
                var defaultAssembly = Default.LoadFromAssemblyName(assemblyName);

                // Default context contains this assembly, no need to load it from elsewhere
                return null;
            }
            catch
            {
                // Allow to fail. Means we manually try to find the assembly
            }

            foreach (var assembly in _assemblies)
            {
                if (assembly.FullName != assemblyName.FullName)
                {
                    continue;
                }

                return LoadFromAssemblyPath(assembly.Location);
            }

            return null;
        }
    }
}
