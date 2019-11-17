using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class TreeViewViewModel : ViewModelBase
    {
        private TypeManager _typeManager = new TypeManager();

        public ObservableCollection<TreeViewTypeElement> ReferencedTypes
        {
            get
            {
                if (_referencedTypes != null)
                {
                    return _referencedTypes;
                }
                else
                {
                    _referencedTypes = new ObservableCollection<TreeViewTypeElement>
                    {
                        new TreeViewTypeElement(_typeManager)
                    };
                    _referencedTypes[0].Name = "First";
                    return _referencedTypes;
                }
            }
            set { ReferencedTypes = value; }
        }

        private ObservableCollection<TreeViewTypeElement> _referencedTypes;
    }
}
