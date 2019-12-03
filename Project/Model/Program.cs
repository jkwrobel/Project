using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            List<Type> types = DllReader.LoadConnectionTypes(Directory.GetCurrentDirectory());
            var constructorInfos = types[12].GetProperties(BindingFlags.Public | BindingFlags.Static |
                                                            BindingFlags.NonPublic | BindingFlags.Instance);

            var test1 = constructorInfos[0].GetType();
            var test2 = constructorInfos[0].PropertyType;
            Console.WriteLine(constructorInfos[0].ToString());

            //System.Reflection.MemberInfo[] types5 = types[0].GetProperties(); ;
            //foreach (Type type in types)
            //{
            //    var types0 = type.GetMethods(BindingFlags.NonPublic);
            //    var types1 = type.GetNestedTypes(BindingFlags.NonPublic);
            //    var types2 = type.GetConstructors(BindingFlags.NonPublic);
            //    var types3 = type.GetFields(BindingFlags.NonPublic);
            //    var types4 = type.GetProperties(BindingFlags.NonPublic);
            //    types5 = type.GetMembers();
            //    foreach (MemberInfo type2 in types5)
            //    {
            //        Console.WriteLine(type2.Name);
            //    }
            //}
            DllTypeManager dllTypeManager = new DllTypeManager();
            var test = dllTypeManager.GetRootTypes();
            Console.WriteLine("test");



        }
    }
}
