using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;

namespace QteaLib
{
    public class TeaPluginManager
    {
        public List<ITeaPlugin> _plugins = new List<ITeaPlugin>();
        private string pluginPath = "";

        public TeaPluginManager(string _pluginPath)
        {
            pluginPath = _pluginPath;
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolve);
        }

        private Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyPath = Path.Combine(pluginPath, args.Name);
            if (!File.Exists(assemblyPath))
            {
                return null;
            }
            else
            {
                var assemb = Assembly.LoadFrom(assemblyPath);
                return assemb;
            }
        }

        /// <summary>
        ///     This should return an ITeaPlugin
        /// </summary>
        /// <param name="name">name of the assembly for this plugin</param>
        /// <returns>bool success</returns>
        public bool LoadPlugin(string name, string entry)
        {
            var plugin  = AppDomain.CurrentDomain.Load(name);
            var assem   = AppDomain.CurrentDomain.GetAssemblies();
            var type    = plugin.GetLoadableTypes().First();
            var main    = plugin.GetCallableMain(type, entry);
            var instance = Activator.CreateInstance(type);

            // Invoke our plugin's .ctor & 'entry' then return this plugin
            main.Invoke(instance, null);
            return (instance != null);
        }

        public void LoadAllPlugins()
        {
            List<string> files = Directory.GetFiles(pluginPath).ToList();
            foreach(var f in files)
            {
                if(!LoadPlugin(f.ToString(), "Run"))
                {
                    throw new Exception("Plugin Load Exception!");
                }
            }
        }
    }
}
