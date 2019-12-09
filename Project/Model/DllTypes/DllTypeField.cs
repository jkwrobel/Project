using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.DllTypes
{
    [DataContract]
    class DllTypeField : ATypeRepresentation
    {
        private FieldInfo _repFieldInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeField(FieldInfo repFieldInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repFieldInfo = repFieldInfo;
            RepresentationType = DllType.Field;
            Name = GenerateName();
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                _addFieldType(_repFieldInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addFieldType(FieldInfo repFieldInfo)
        {
            if (!DllTypeManager.RememberedTypesDictionary.ContainsKey(repFieldInfo.FieldType.GUID))
            {

                DllTypeManager.RememberedTypesDictionary.Add(repFieldInfo.FieldType.GUID, new DllTypeClass(repFieldInfo.FieldType));
            }
            ReferencedTypes.Add(DllTypeManager.RememberedTypesDictionary[repFieldInfo.FieldType.GUID]);
        }

        private string GenerateName()
        {
            string name = "";
            if (_repFieldInfo.IsPrivate) name += "private ";
            if (_repFieldInfo.IsPublic) name += "public ";

            if (_repFieldInfo.IsStatic) name += "static ";
            name += "Field ";
            name += _repFieldInfo.Name;
            return name;
        }

        public override string Name { get; set; }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
