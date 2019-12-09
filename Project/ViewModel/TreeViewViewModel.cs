using Model;
using System.Collections.ObjectModel;
namespace ViewModel
{
    public class TreeViewViewModel : ViewModelBase
    {

        public IFilePathChooser FileXmlPathOpener { get; set; }
        public IFilePathChooser FileDllPathOpener { get; set; }
        public IFilePathChooser FilePathCreator { get; set; }
        public ITypeManager TypeManagerInst;
        public bool HasTypeManager = false;
        public bool HasTypesGenerated = false;

        public ObservableCollection<TreeViewTypeElement> ReferencedTypes { get; set; } = new ObservableCollection<TreeViewTypeElement>();

        public virtual void GenerateRoots()
        {
            HasTypesGenerated = true;
            ReferencedTypes.Clear();
            foreach (ATypeRepresentation typePlaceholder in TypeManagerInst.GetRootTypes())
            {
                ReferencedTypes.Add(new TreeViewTypeElement(TypeManagerInst, typePlaceholder));
            }
        }


        public AssignDataSourceCommand AssignDataSourceDll
        {
            get
            {
                return new AssignDllTypeManagerCommand(this);
            }
        }

        public AssignDataSourceCommand AssignDataSourceXml
        {
            get
            {
                return new AssignXmlTypeManagerCommand(this);
            }
        }

        public ShowTreeViewCommand ShowTreeViewCommand
        {
            get
            {
                if (_showTreeViewCommand == null)
                {
                    _showTreeViewCommand = new ShowTreeViewCommand(this);
                    return _showTreeViewCommand;
                }
                else
                {
                    return _showTreeViewCommand;
                }
            }
            set
            {

            }
        }
        public WriteMetadataToXml WriteMetadataToXml
        {
            get
            {
                if (_showTreeViewCommand == null)
                {
                    _writeMetadataToXml = new WriteMetadataToXml(this);
                    return _writeMetadataToXml;
                }
                else
                {
                    return _writeMetadataToXml;
                }
            }
            set
            {

            }
        }

        private ShowTreeViewCommand _showTreeViewCommand;
        private WriteMetadataToXml _writeMetadataToXml;
    }
}
