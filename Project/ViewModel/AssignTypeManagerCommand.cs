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
        protected ITypeManager _typeManager;
        protected TreeViewViewModel _treeViewViewModel;
        public AssignDataSourceCommand(TreeViewViewModel treeViewViewModel, ITypeManager typeManager)
        {
            _treeViewViewModel = treeViewViewModel;
            _typeManager = typeManager;
        }
        protected static bool _sourceAlreadyAssigned = false;
        public bool CanExecute(object parameter)
        {
            return !_sourceAlreadyAssigned;
        }

        public virtual void Execute(object parameter)
        {
            _sourceAlreadyAssigned = true;
            _typeManager.InitTypeManager();
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            _treeViewViewModel.TypeManagerInst = _typeManager;
            _treeViewViewModel.HasTypeManager = true;
            _treeViewViewModel.HasTypesGenerated = true;
            _treeViewViewModel.ShowTreeViewCommand.RaiseCanExecuteChanged();
            _treeViewViewModel.WriteMetadataToXml.RaiseCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged;
    }
}
