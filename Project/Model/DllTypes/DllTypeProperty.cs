using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.DllTypes
{
    class DllTypeProperty : ATypeRepresentation
    {
        private PropertyInfo _repPropertyInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeProperty(PropertyInfo repPropertyInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            RepresentationType = DllType.Property;
            _repPropertyInfo = repPropertyInfo;
        }

        public override bool GenerateReferencedTypes()
        {
            if (!_referencedTypesGenerated)
            {
                if (_repPropertyInfo.PropertyType.Namespace != null && _repPropertyInfo.PropertyType.Namespace.Contains("System"))
                {
                    _referencedTypesGenerated = true;
                    return true;
                }
                _addPropertyType(_repPropertyInfo);
                _referencedTypesGenerated = true;
                return true;
            }

            return false;
        }

        private void _addPropertyType(PropertyInfo propertyInfo)
        {
            if (!DllTypeManager.RememberedTypesDictionary.ContainsKey(propertyInfo.PropertyType.GUID))
            {
                DllTypeManager.RememberedTypesDictionary.Add(propertyInfo.PropertyType.GUID, new DllTypeClass(propertyInfo.PropertyType));
            }
            ReferencedTypes.Add(DllTypeManager.RememberedTypesDictionary[propertyInfo.PropertyType.GUID]);
        }

        public override string Name
        {
            get
            {
                return _repPropertyInfo.ToString();
            }
            set
            {

            }
        }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
