using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Model
{
    public class DllReader
    {
        public static List<Type> ConnectionTypes = new List<Type>();

        public static List<Type> LoadConnectionTypes(string path)
        {
            FileInfo dllFileInfo = new FileInfo(path);

            Assembly assembly = Assembly.LoadFrom(dllFileInfo.FullName);
            ConnectionTypes.AddRange(assembly.GetTypes());

            return ConnectionTypes;
        }

    }
}
