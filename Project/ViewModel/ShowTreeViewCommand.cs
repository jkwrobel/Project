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
    public class ShowTreeViewCommand : ICommand
    {
        private TreeViewViewModel _treeViewViewModel;
        public ShowTreeViewCommand(TreeViewViewModel treeViewViewModel)
        {
            _treeViewViewModel = treeViewViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _treeViewViewModel.GenerateRoots();
        }

        public event EventHandler CanExecuteChanged;
    }
}
