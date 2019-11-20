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
        [TestMethod]
        public void ITypeManagerTest()
        {

        }
    }

    [TestClass]
    public class TypeManagerTests
    {
        [TestMethod]
        public void TypeManagerTest()
        {

        }
    }
}
