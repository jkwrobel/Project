﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Model
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            List<Type> types = DllReader.LoadConnectionTypes(Directory.GetCurrentDirectory());
            var constructorInfos = types[12].GetProperties(BindingFlags.Public | BindingFlags.Static |
                                                            BindingFlags.NonPublic | BindingFlags.Instance);

            var test1 = constructorInfos[0].GetType();
            var test2 = constructorInfos[0].PropertyType;
            Console.WriteLine(constructorInfos[0].ToString());

            DllTypeManager dllTypeManager = new DllTypeManager();
            var test = dllTypeManager.GetRootTypes();

            DllSerializer dllSerializer = DllSerializer.SerializerInstance;

            dllSerializer.SerializeObjectToXMl(dllTypeManager, @"E:\Test.Xml");
            TypeDictionaryHolder typeDictionaryHolder = dllSerializer.DeserializeXmlToObject(@"E:\Test.Xml");
            Console.WriteLine("test");



        }
    }
}
