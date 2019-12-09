using Model;

namespace ViewModel
{
    internal class AssignXmlTypeManagerCommand : AssignDataSourceCommand
    {
        public AssignXmlTypeManagerCommand(TreeViewViewModel treeViewViewModel) : base(treeViewViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            XmlTypeManager xmlTypeManager = new XmlTypeManager();
            xmlTypeManager.AssignPathToFile(_treeViewViewModel.FileXmlPathOpener.GetPathToFile());
            _typeManager = xmlTypeManager;
            base.Execute(parameter);
        }
    }
}
