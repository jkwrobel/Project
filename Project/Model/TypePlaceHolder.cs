using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class TypePlaceholder
    {
        public string Name
        {
            get
            {
                if (!String.IsNullOrEmpty(_name))
                {
                    return _name;
                }
                else
                {
                    return "ValueNotSet";
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                }
                _name = value;
            } 
        }

        public List<TypePlaceholder> ReferencedTypes
        {
            get
            {
                if (_referencedTypes != null)
                {
                    return _referencedTypes;
                }
                else
                {
                    return PlaceholderForTypeManagement.PlaceholderGetTypesForType(this._name);
                }
            }
            set { _referencedTypes = ReferencedTypes; }
        }

        private List<TypePlaceholder> _referencedTypes = null;
        private string _name;
    }
}
