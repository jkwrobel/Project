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

        public ObservableCollection<TypePlaceholder> ReeferencedTypes
        {
            get
            {
                if (_referencedTypes != null)
                {
                    return _referencedTypes;
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

        private ObservableCollection<TypePlaceholder> _referencedTypes = null;
        private string _name;
    }
}
