using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Model.DllTypes
{
    [DataContract]
    public class DllTypeConstructor : ATypeRepresentation
    {
        private ConstructorInfo _repConstructorInfo;
        private bool _referencedTypesGenerated = false;
        public DllTypeConstructor(ConstructorInfo repConstructorInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repConstructorInfo = repConstructorInfo;
            RepresentationType = DllType.Constructor;
            Name = GenerateName();
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                _addAttributes(_repConstructorInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addAttributes(ConstructorInfo constructorInfo)
        {
            foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
            {
                ReferencedTypes.Add(new DllTypeParameter(parameterInfo));
            }
        }

        private string GenerateName()
        {
            string name = "";
            if (_repConstructorInfo.IsPrivate) name += "private ";
            if (_repConstructorInfo.IsPublic) name += "public ";

            if (_repConstructorInfo.IsAbstract) name += "abstract ";

            name += "Constructor ";
            name += _repConstructorInfo.Name;
            return name;
        }

        public override string Name { get; set; }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }

}
