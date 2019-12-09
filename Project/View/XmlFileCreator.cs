using Microsoft.Win32;
using ViewModel;

namespace View
{
    internal class XmlFileCreator : IFilePathChooser
    {
        public string GetPathToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"E:\";
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML Files|*.xml";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }
    }
}