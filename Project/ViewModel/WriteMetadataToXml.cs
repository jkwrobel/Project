using Model;
using System;
using System.Windows.Input;

namespace ViewModel
{
    public class WriteMetadataToXml : ICommand
    {
        private TreeViewViewModel _treeViewViewModel;
        public WriteMetadataToXml(TreeViewViewModel treeViewViewModel)
        {
            _treeViewViewModel = treeViewViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _treeViewViewModel.HasTypesGenerated;
        }

        public void Execute(object parameter)
        {

            DllSerializer.SerializerInstance.SerializeObjectToXMl((DllTypeManager)_treeViewViewModel.TypeManagerInst,
                _treeViewViewModel.FilePathCreator.GetPathToFile());
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
