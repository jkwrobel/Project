using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class TreeViewTypeElement
    {
        public TreeViewTypeElement(TypeManager typeManager)
        {
            _typeManager = typeManager;
        }

        private TypeManager _typeManager;
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
                    List<TypePlaceholder> typesList =
                        _typeManager.GetTypePlaceholdersForTypePlaceholder(this._name);
                    ObservableCollection<TypePlaceholder> typePlaceholders = new ObservableCollection<TypePlaceholder>();
                    foreach (TypePlaceholder typeElement in typesList)
                    {
                        TypePlaceholder tempType = new TypePlaceholder
                        {
                            Name = typeElement.Name
                        };
                        typePlaceholders.Add(tempType);
                    }

                    return typePlaceholders;
                }
            }
            set { _referencedTypes = ReferencedTypes; }
        }

        private ObservableCollection<TypePlaceholder> _referencedTypes = null;
        private string _name;
    }
}
