using System;
using System.Collections.Generic;
using System.Reflection;
using Rumi.LCNetworks.API;

namespace Rumi.LCNetworks
{
    static class ReflectionManager
    {
        static ReflectionManager()
        {
            assemblys = AppDomain.CurrentDomain.GetAssemblies();

            {
                List<Type> result = new List<Type>();
                for (int assemblysIndex = 0; assemblysIndex < assemblys.Count; assemblysIndex++)
                {
                    Type[] types = assemblys[assemblysIndex].GetTypes();
                    for (int typesIndex = 0; typesIndex < types.Length; typesIndex++)
                    {
                        Type type = types[typesIndex];
                        result.Add(type);
                    }
                }

                types = result.ToArray();
            }

            {
                List<Type> result = new List<Type>();
                for (int i = 0; i < types.Count; i++)
                {
                    Type type = types[i];
                    if (!type.IsAbstract && typeof(LCNHNetworkBehaviour).IsAssignableFrom(type))
                        result.Add(type);
                }

                networks = result.ToArray();
            }
        }

        /// <summary>
        /// All loaded assemblys
        /// </summary>
        public static IReadOnlyList<Assembly> assemblys { get; }

        /// <summary>
        /// All loaded types
        /// </summary>
        public static IReadOnlyList<Type> types { get; }

        public static IReadOnlyList<Type> networks { get; }
    }
}
