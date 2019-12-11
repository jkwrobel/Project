using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Model.DllTypes
{
    [DataContract]
    public class DllTypeMethod : ATypeRepresentation
    {
        private MethodInfo _repMethodInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeMethod(MethodInfo repMethodInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repMethodInfo = repMethodInfo;
            RepresentationType = DllType.Method;
            Name = GenerateName();
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                _addParameters(_repMethodInfo);
                _addReturnType(_repMethodInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addParameters(MethodInfo repMethodInfo)
        {
            foreach (ParameterInfo parameterInfo in repMethodInfo.GetParameters())
            {
                ReferencedTypes.Add(new DllTypeParameter(parameterInfo));
            }
        }

        private void _addReturnType(MethodInfo repMethodInfo)
        {
            ReferencedTypes.Add(new DllTypeReturn(repMethodInfo.ReturnParameter));
        }

        private string GenerateName()
        {
            string name = "";

            if (_repMethodInfo.IsPrivate) name += "private ";
            if (_repMethodInfo.IsPublic) name += "public ";

            if (_repMethodInfo.IsAbstract) name += "abstract ";
            if (_repMethodInfo.IsVirtual) name += "virtual ";
            if (_repMethodInfo.IsStatic) name += "static ";
            name += "Method ";
            name += _repMethodInfo.Name;
            return name;
        }

        public override string Name { get; set; }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
