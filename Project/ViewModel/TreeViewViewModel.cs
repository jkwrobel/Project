using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;
namespace ViewModel
{
    public class TreeViewViewModel : ViewModelBase
    {


        public ITypeManager TypeManagerInst;

        public ObservableCollection<TreeViewTypeElement> ReferencedTypes
        {
            get { return _referencedTypes; }
            set { _referencedTypes = value; }
        }

        public void GenerateRoots()
        {
            _referencedTypes.Clear();
            foreach (ATypeRepresentation typePlaceholder in TypeManagerInst.GetRootTypes())
            {
                _referencedTypes.Add(new TreeViewTypeElement(TypeManagerInst, typePlaceholder));
            }
        }

        public AssignDataSourceCommand AssignDataSourceRandom
        {
            get
            {
                return new AssignDataSourceCommand(this, new TypeManager());
            }
        }

        public ShowTreeViewCommand ShowTreeViewCommand
        {
            get
            {
                return new ShowTreeViewCommand(this);
            }
        }

        private ObservableCollection<TreeViewTypeElement> _referencedTypes = new ObservableCollection<TreeViewTypeElement>();
    }
}
