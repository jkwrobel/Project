using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Model.DllTypes
{
    [DataContract]
    public class DllTypeProperty : ATypeRepresentation
    {
        private PropertyInfo _repPropertyInfo;

        private bool _referencedTypesGenerated = false;

        public DllTypeProperty(PropertyInfo repPropertyInfo)
        {
            ReferencedTypes = new List<ATypeRepresentation>();
            RepresentationType = DllType.Property;
            _repPropertyInfo = repPropertyInfo;
            Name = GenerateName();
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

        private string GenerateName()
        {
            string name = "";

            name += "Property ";
            name += _repPropertyInfo.Name;
            return name;
        }

        public override string Name { get; set; }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }
    }
}
