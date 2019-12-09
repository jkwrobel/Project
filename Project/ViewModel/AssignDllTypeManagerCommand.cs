using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    class AssignDllTypeManagerCommand : AssignDataSourceCommand
    {
        public AssignDllTypeManagerCommand(TreeViewViewModel treeViewViewModel) : base(treeViewViewModel)
        {

        }

        public override void Execute(object parameter)
        {
            DllTypeManager tempDllTypeManager = new DllTypeManager();
            tempDllTypeManager.AssignPathToFile(_treeViewViewModel.FileDllPathOpener.GetPathToFile());
            _typeManager = tempDllTypeManager;
            base.Execute(parameter);
        }
        
    }
}
