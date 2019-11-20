using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class TypePlaceholder : ATypeRepresentation
    {
        public override string Name
        {
            get
            {
                if (!String.IsNullOrEmpty(_name))
                {
                    return _name;
                }
                else
                {
                    return "ValueNotSetModel";
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

        public override List<ATypeRepresentation> ReferencedTypes
        {
            get
            {
                if (_referencedTypes != null)
                {
                    return _referencedTypes;
                }
                else
                {
                    return PlaceholderForTypeManagement.PlaceholderGetTypesForType();
                }
            }
            set { _referencedTypes = ReferencedTypes; }
        }
    }
}
