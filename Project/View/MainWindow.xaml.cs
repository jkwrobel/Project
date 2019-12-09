using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            TreeViewViewModel treeViewViewModel = new TreeViewViewModel();
            DataContext = treeViewViewModel;
            treeViewViewModel.FileXmlPathOpener = new XmlFileOpener();
            treeViewViewModel.FilePathCreator = new XmlFileCreator();
            treeViewViewModel.FileDllPathOpener = new DllFileOpener();
            InitializeComponent();
        }

    }
}
