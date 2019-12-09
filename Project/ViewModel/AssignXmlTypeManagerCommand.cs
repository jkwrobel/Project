using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    class AssignXmlTypeManagerCommand : AssignDataSourceCommand
    {
        public AssignXmlTypeManagerCommand(TreeViewViewModel treeViewViewModel) : base(treeViewViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            XmlTypeManager xmlTypeManager = new XmlTypeManager();
            xmlTypeManager.AssignPathToFile(_treeViewViewModel.FilePathOpener.GetPathToFile());
            _typeManager = xmlTypeManager;
            base.Execute(parameter);
        }
    }
}
