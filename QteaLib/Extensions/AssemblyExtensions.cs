using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QteaLib
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static MethodInfo GetCallableMain(this Assembly assembly, Type type, string main)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return type.GetMethod(main);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
