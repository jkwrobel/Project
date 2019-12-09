using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Model.DllTypes
{
    [DataContract]
    internal class DllTypeParameter : ATypeRepresentation
    {
        private ParameterInfo _repParameterInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeParameter(ParameterInfo repParameterInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repParameterInfo = repParameterInfo;
            RepresentationType = DllType.Field;
            Name = GenerateName();
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                if (_repParameterInfo.ParameterType.Namespace != null && _repParameterInfo.ParameterType.Namespace.Contains("System"))
                {
                    _referencedTypesGenerated = true;
                    return true;
                }
                _addParameterType(_repParameterInfo);
                _referencedTypesGenerated = true;
            }

            return false;
        }

        private void _addParameterType(ParameterInfo repParameterInfo)
        {
            if (!DllTypeManager.RememberedTypesDictionary.ContainsKey(repParameterInfo.ParameterType.GUID))
            {
                DllTypeManager.RememberedTypesDictionary.Add(repParameterInfo.ParameterType.GUID, new DllTypeClass(repParameterInfo.GetType()));
            }
            ReferencedTypes.Add(DllTypeManager.RememberedTypesDictionary[repParameterInfo.ParameterType.GUID]);
        }

        private string GenerateName()
        {
            string name = "";

            if (_repParameterInfo.IsOptional) name += "optional ";

            if (_repParameterInfo.IsIn) name += "In ";
            if (_repParameterInfo.IsOut) name += "Out ";
            if (_repParameterInfo.IsRetval) name += "Retval ";

            name += "Parameter ";
            name += ("pos: " + _repParameterInfo.Position + " ");
            name += _repParameterInfo.Name;
            if (_repParameterInfo.HasDefaultValue)
            {
                name += (" def: " + _repParameterInfo?.RawDefaultValue?.ToString());
            }
            return name;
        }

        public override string Name { get; set; }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
