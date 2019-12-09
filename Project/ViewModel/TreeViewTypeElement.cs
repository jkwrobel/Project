using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class TreeViewTypeElement
    {
        public TreeViewTypeElement(ITypeManager typeManager, ATypeRepresentation typePlaceholder)
        {
            _typeManager = typeManager;
            _typePlaceholder = typePlaceholder;
        }

        private ITypeManager _typeManager;
        private ATypeRepresentation _typePlaceholder;
        public string Name
        {
            get
            {
                return _typePlaceholder.Name;
            }
        }

        public ObservableCollection<ATypeRepresentation> ReferencedTypes
        {
            get
            {
                if (_referencedTypes != null)
                {
                    return _referencedTypes;
                }
                else
                {
                    List<ATypeRepresentation> typesList = _typeManager.GetChildrenForType(_typePlaceholder);
                    ObservableCollection<ATypeRepresentation> typePlaceholders = new ObservableCollection<ATypeRepresentation>();
                    foreach (ATypeRepresentation typeElement in typesList)
                    {
                        typePlaceholders.Add(typeElement);
                    }

                    return typePlaceholders;
                }
            }
            set { _referencedTypes = ReferencedTypes; }
        }

        private ObservableCollection<ATypeRepresentation> _referencedTypes = null;
        private string _name;
    }
}
