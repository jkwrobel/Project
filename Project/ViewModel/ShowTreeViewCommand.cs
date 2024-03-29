﻿using System;
using System.Windows.Input;

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
            return _treeViewViewModel.HasTypeManager;
        }

        public void Execute(object parameter)
        {
            _treeViewViewModel.GenerateRoots();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
