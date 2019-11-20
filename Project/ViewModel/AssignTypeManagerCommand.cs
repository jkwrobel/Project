using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class AssignDataSourceCommand : ICommand
    {
        private ITypeManager _typeManager;
        private TreeViewViewModel _treeViewViewModel;
        public AssignDataSourceCommand(TreeViewViewModel treeViewViewModel, ITypeManager typeManager)
        {
            _treeViewViewModel = treeViewViewModel;
            _typeManager = typeManager;
        }
        private static bool _sourceAlreadyAssigned = false;
        public bool CanExecute(object parameter)
        {
            return !_sourceAlreadyAssigned;
        }

        public void Execute(object parameter)
        {
            _sourceAlreadyAssigned = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            _treeViewViewModel.TypeManagerInst = _typeManager;
        }

        public event EventHandler CanExecuteChanged;
    }
}
