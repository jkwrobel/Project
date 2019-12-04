using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DllReader
    {
        public static List<Type> ConnectionTypes = new List<Type>();

        public static List<Type> LoadConnectionTypes(string path)
        {
            DirectoryInfo dllDirectory = new DirectoryInfo(path + "/test");
            FileInfo[] dlls = dllDirectory.GetFiles("*.dll");
            foreach (FileInfo dllFileInfo in dlls)
            {
                Assembly assembly = Assembly.LoadFrom(dllFileInfo.FullName);
                ConnectionTypes.AddRange(assembly.GetTypes());
            }

            return ConnectionTypes;
        }

    }
}
