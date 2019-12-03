using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.DllTypes
{
    class DllTypeField : ATypeRepresentation
    {
        private FieldInfo _repFieldInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeField(FieldInfo repFieldInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            _repFieldInfo = repFieldInfo;
            
            RepresentationType = DllType.Field;
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                if (_repFieldInfo.FieldType.Namespace != null && _repFieldInfo.FieldType.Namespace.Contains("System"))
                {
                    _referencedTypesGenerated = true;
                    return true;
                }
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

        public override string Name
        {
            get { return _repFieldInfo.ToString(); }
            set
            {

            }
        }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
