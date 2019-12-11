using System;
using Model;

namespace ViewModel
{
    internal class AssignDllTypeManagerCommand : AssignDataSourceCommand
    {
        public AssignDllTypeManagerCommand(TreeViewViewModel treeViewViewModel) : base(treeViewViewModel)
        {

        }

        public override void Execute(object parameter)
        {
            try
            {


                DllTypeManager tempDllTypeManager = new DllTypeManager();
                tempDllTypeManager.AssignPathToFile(_treeViewViewModel.FileDllPathOpener.GetPathToFile());
                _typeManager = tempDllTypeManager;
                base.Execute(parameter);
            }
            catch (ArgumentException ae)
            {
                return;
            }
        }

        }
    }
