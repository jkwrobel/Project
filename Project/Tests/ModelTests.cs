using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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



        }
    }

    [TestClass]
    public class TypeManagerTests
    {
        [TestMethod]
        public void TypeManagerTest()
        {
            RandomTypeManager randomTypeManager = new RandomTypeManager();
            Assert.IsTrue(randomTypeManager.GetRootTypes().Count > 0);
            Assert.IsTrue(randomTypeManager.GetChildrenForType(new TypePlaceholder(){ Name = "test"}).Count > 0);
        }
    }
}
