using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Model.DllTypes;

namespace Model
{
    [TestClass]
    public class ATypeRepresentationTests
    {
        public class TestTypeRepresentation : ATypeRepresentation
        {
            public override string Name { get; set; }
            public override bool GenerateReferencedTypes()
            {
                throw new NotImplementedException();
            }

            public override List<ATypeRepresentation> ReferencedTypes { get; set; }
        }
        [TestMethod]
        public void ATypeRepresentationTest()
        {
            TestTypeRepresentation testType = new TestTypeRepresentation();
            testType.Name = "test";
            testType.ReferencedTypes = new List<ATypeRepresentation>()
            {
                new TypePlaceholder(){ Name = "test2"}
            };
            Assert.AreEqual("test", testType.Name);
            Assert.AreEqual("test2", testType.ReferencedTypes[0].Name);
        }
    }

    [TestClass]
    public class ITypeManagerTests
    {
        public class TestTypeManager : ITypeManager
        {
            public List<ATypeRepresentation> roots;
            public List<ATypeRepresentation> children;
            public void InitTypeManager()
            {
                throw new NotImplementedException();
            }

            public List<ATypeRepresentation> GetRootTypes()
            {
                return roots;
            }

            public List<ATypeRepresentation> GetChildrenForType(ATypeRepresentation typePlaceholder)
            {
                return children;
            }
        }
        [TestMethod]
        public void ITypeManagerTest()
        {
            TestTypeManager testTypeManager = new TestTypeManager();
            List<ATypeRepresentation> myRoots = new List<ATypeRepresentation>();
            List<ATypeRepresentation> myChildren = new List<ATypeRepresentation>();
            testTypeManager.children = myChildren;
            testTypeManager.roots = myRoots;
            Assert.AreEqual(testTypeManager.children, myChildren);
            Assert.AreEqual(testTypeManager.roots, myRoots);
        }
    }

    [TestClass]
    public class DllTypeManagerTests
    {
        [TestMethod]
        public void DllTypeManagerTest()
        {
            
        }
    }

    [TestClass]
    public class DllReaderTests
    {
        [TestMethod]
        public void DllReaderTest()
        {
            string pathToTest = Environment.CurrentDirectory;
            for (int i = 0; i < 4; i++)
            {
                pathToTest = Directory.GetParent(pathToTest).FullName;
            }
            string testPath = Path.Combine(pathToTest, "testData\\TPA.ApplicationArchitecture.dll");
            List<Type> types = DllReader.LoadConnectionTypes(testPath);
            Assert.IsNotNull(types);
            Assert.AreEqual(types.Count, 20);
        }
    }

    [TestClass]
    public class DllSerializerTests
    {
        public class TestClass
        {
            public int TestInt = 4;
        }
        [TestMethod]
        public void DllSerializeObject()
        {
            DllSerializer dllSerializer = DllSerializer.SerializerInstance;
            TypeDictionaryHolder typeDictionaryHolder = new TypeDictionaryHolder();
            typeDictionaryHolder.LocalRememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();
            typeDictionaryHolder.LocalRememberedTypesDictionary.Add(Guid.NewGuid(),
                new DllTypeField(typeof(TestClass).GetField("TestInt")));
            dllSerializer.SerializeObjectToXMl(typeDictionaryHolder, Environment.CurrentDirectory+"//test.xml");
            Assert.IsTrue(File.Exists(Environment.CurrentDirectory+"//test.xml"));
        }

        [TestMethod]
        public void DllDeserializeObject()
        {
            DllSerializer dllSerializer = DllSerializer.SerializerInstance;
            TypeDictionaryHolder typeDictionaryHolder = new TypeDictionaryHolder();
            typeDictionaryHolder.LocalRememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();
            typeDictionaryHolder.LocalRememberedTypesDictionary.Add(Guid.NewGuid(),
                new DllTypeField(typeof(TestClass).GetField("TestInt")));
            dllSerializer.SerializeObjectToXMl(typeDictionaryHolder, Environment.CurrentDirectory + "//test.xml");
            TypeDictionaryHolder desTypeDictionaryHolder = dllSerializer.DeserializeXmlToObject(Environment.CurrentDirectory + "//test.xml");
            Assert.AreEqual(desTypeDictionaryHolder.LocalRememberedTypesDictionary.Count,
                typeDictionaryHolder.LocalRememberedTypesDictionary.Count);
        }
    }
}
