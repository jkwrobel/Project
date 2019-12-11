using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
                new DllTypeProperty(typeof(TestTypeRepresentation).GetProperties()[0]){ Name = "test2"}
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
            DllTypeManager dllTypeManager = new DllTypeManager();
            string pathToTest = Environment.CurrentDirectory;
            for (int i = 0; i < 4; i++)
            {
                pathToTest = Directory.GetParent(pathToTest).FullName;
            }
            string testPath = Path.Combine(pathToTest, "testData\\TPA.ApplicationArchitecture.dll");
            dllTypeManager.AssignPathToFile(testPath);
            dllTypeManager.InitTypeManager();
            Assert.IsTrue(dllTypeManager.LocalRememberedTypesDictionary.Count > 0);
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
            Assert.IsTrue(types.Count > 0);
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

    [TestClass]
    public class TypeDictionaryHolderTests
    {
        [TestMethod]
        public void TypeDictionaryHolderTest()
        {
            TypeDictionaryHolder typeDictionaryHolder = new TypeDictionaryHolder();
            typeDictionaryHolder.LocalRememberedTypesDictionary = new Dictionary<Guid, ATypeRepresentation>();
            typeDictionaryHolder.LocalRememberedTypesDictionary.Add(Guid.NewGuid(),
                new DllTypeMethod(this.GetType().GetMethods()[0]));
            Assert.AreEqual(1, typeDictionaryHolder.LocalRememberedTypesDictionary.Count);
        }
    }

    [TestClass]
    public class DllTypesTests
    {
        public class TestClass
        {
            public TestClass(int ia)
            {}
            public int b;
            public int c(SmallClass d)
            {
                return 5;
            }
            public SmallClass e { get; set; }
        }

        public class SmallClass
        {
            public int k = 4;
        }

        [TestMethod]
        public void DllTypeClassTest()
        {
            DllTypeClass dllTypeClass = new DllTypeClass(typeof(TestClass));
            dllTypeClass.GenerateReferencedTypes();
            Assert.AreEqual(13, dllTypeClass.ReferencedTypes.Count);
        }

        [TestMethod]
        public void DllTypeConstructorTest()
        {
            DllTypeConstructor dllTypeConstructor = new DllTypeConstructor(typeof(TestClass).GetConstructors()[0]);
            dllTypeConstructor.GenerateReferencedTypes();
            Assert.AreEqual(1,dllTypeConstructor.ReferencedTypes.Count);
        }

        [TestMethod]
        public void DllTypeFieldTest()
        {
            DllTypeField dllTypeField = new DllTypeField(typeof(TestClass).GetFields()[0]);
            dllTypeField.GenerateReferencedTypes();
            Assert.IsTrue(dllTypeField.ReferencedTypes.Count > 0);
        }

        [TestMethod]
        public void DllTypeMethodTest()
        {
            DllTypeMethod dllTypeMethod = new DllTypeMethod(typeof(TestClass).GetMethods()[0]);
            dllTypeMethod.GenerateReferencedTypes();
            Assert.IsTrue(dllTypeMethod.ReferencedTypes.Count > 0);
        }

        [TestMethod]
        public void DllTypeParameterTest()
        {
            DllTypeParameter dllTypeParameter = null;
            foreach (MethodInfo methodInfo in typeof(TestClass).GetMethods())
            {
                if (methodInfo.GetParameters().Length > 0)
                {
                    dllTypeParameter = new DllTypeParameter(
                        methodInfo.GetParameters()[0]);
                    break;
                }
            }
            
            dllTypeParameter.GenerateReferencedTypes();
            Assert.IsTrue(dllTypeParameter.ReferencedTypes.Count > 0);
        }

        [TestMethod]
        public void DllTypePropertyTest()
        {
            DllTypeProperty dllTypeProperty = new DllTypeProperty(typeof(TestClass).GetProperties()[0]);
            dllTypeProperty.GenerateReferencedTypes();
            Assert.IsTrue(dllTypeProperty.ReferencedTypes.Count > 0);
        }

        [TestMethod]
        public void DllTypeReturnTest()
        {
            DllTypeReturn dllTypeReturn = new DllTypeReturn(typeof(TestClass).GetMethods()[0].ReturnParameter);
            dllTypeReturn.GenerateReferencedTypes();
            Assert.IsTrue(dllTypeReturn.ReferencedTypes.Count > 0);
        }
    }
}
