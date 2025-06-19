using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Rumi.LCNetworks.API;

namespace Rumi.LCNetworks
{
    static class ReflectionManager
    {
        static ReflectionManager()
        {
            assemblys = AppDomain.CurrentDomain.GetAssemblies();

            types = assemblys.SelectMany(x =>
            {
                try
                {
                    return x.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    return e.Types.Where(x => x != null).ToArray();
                }
            }).ToArray();

            networks = types.Where(static x =>
            {
                try
                {
                    return !x.IsAbstract && typeof(LCNHNetworkBehaviour).IsAssignableFrom(x);
                }
                catch
                {
                    return false;
                }
            }).ToArray();
        }

        /// <summary>
        /// All loaded assemblys
        /// </summary>
        public static IReadOnlyList<Assembly> assemblys { get; } = Array.Empty<Assembly>();

        /// <summary>
        /// All loaded types
        /// </summary>
        public static IReadOnlyList<Type> types { get; } = Array.Empty<Type>();

        public static IReadOnlyList<Type> networks { get; } = Array.Empty<Type>();
    }
}
