using System;
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

        public ObservableCollection<TypePlaceholder> ReferencedTypes
        {
            get
            {
                if (_referencedTypes != null)
                {
                    return _referencedTypes;
                }
                else
                {
                    return PlaceholderForTypeManagement.PlaceholderGetTypesForType(this);
                }
            }
            set { _referencedTypes = ReferencedTypes; }
        }

        private ObservableCollection<TypePlaceholder> _referencedTypes = null;
        private string _name;
    }
}
