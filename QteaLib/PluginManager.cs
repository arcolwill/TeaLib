using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.File;
using System.IO;

namespace QteaLib
{
    public class PluginManager
    {
        public List<ITeaPlugin> _plugins = new List<ITeaPlugin>();
        
        public ITeaPlugin LoadPlugin(string p)
        {
            // Load an assembly using reflection
            /*
            using (var reader = new StreamReader())
            {
            }
            */
            throw new NotImplementedException();
        }
    }
}
