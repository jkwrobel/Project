using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Model.DllTypes
{
    [DataContract]
    public class DllTypeClass : ATypeRepresentation
    {
        private Type _repType;
        private bool _referencedTypesGenerated = false;
        public DllTypeClass(Type repType)
        {
            _repType = repType;
            ReferencedTypes = new List<ATypeRepresentation>();
            RepresentationType = DllType.Class;
            Name = GenerateName();
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                if (_repType?.DeclaringType?.Namespace != null && (_repType.DeclaringType.Namespace.Contains("System") || _repType.DeclaringType.BaseType?.Name == "Enum"))
                {
                    _referencedTypesGenerated = true;
                    return true;
                }
                _addConstructors(_repType);
                _addNestedTypes(_repType);
                _addFields(_repType);
                _addProperties(_repType);
                _addMethods(_repType);

                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private string GenerateName()
        {
            string name = "";
            if (_repType.IsPublic) name += "public ";
            if (_repType.IsAbstract && _repType.IsSealed) name += "Static ";
            if (_repType.IsAbstract && !_repType.IsSealed) name += "Abstract ";
            if (_repType.IsNestedPrivate) name += "Nested private ";
            if (_repType.IsNestedPublic) name += "Nested public";
            if (_repType.IsEnum) name += "Enum ";
            if (_repType.IsInterface) name += "Interface";
            if (_repType.IsClass) name += "Class ";

            name += "";
            name += _repType.Name;
            return name;
        }

        public override string Name { get; set; }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }

        private void _addNestedTypes(Type repType)
        {
            Type[] nestedTypes = repType.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var nestedType in nestedTypes)
            {
                if (!DllTypeManager.RememberedTypesDictionary.ContainsKey(nestedType.GUID))
                {
                    DllTypeManager.RememberedTypesDictionary.Add(nestedType.GUID, new DllTypeClass(nestedType));
                }
                ReferencedTypes.Add(DllTypeManager.RememberedTypesDictionary[nestedType.GUID]);
            }

        }

        private void _addConstructors(Type repType)
        {
            ConstructorInfo[] cosConstructorInfos = repType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public |
                                                                            BindingFlags.Static | BindingFlags.Instance);
            foreach (ConstructorInfo constructorInfo in cosConstructorInfos)
            {
                ReferencedTypes.Add(new DllTypeConstructor(constructorInfo));
            }
        }

        private void _addFields(Type repType)
        {
            FieldInfo[] fields = repType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                ReferencedTypes.Add(new DllTypeField(field));
            }
        }

        private void _addProperties(Type repType)
        {
            PropertyInfo[] properties = repType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic |
                                                              BindingFlags.Instance | BindingFlags.Static);
            foreach (PropertyInfo property in properties)
            {
                ReferencedTypes.Add(new DllTypeProperty(property));
            }
        }

        private void _addMethods(Type repType)
        {
            MethodInfo[] methods = repType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                                      BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                ReferencedTypes.Add(new DllTypeMethod(method));
            }
        }
    }
}
