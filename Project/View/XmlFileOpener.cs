using Microsoft.Win32;
using ViewModel;

namespace View
{
    internal class XmlFileOpener : IFilePathChooser
    {
        public string GetPathToFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"E:\";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }
    }
}
